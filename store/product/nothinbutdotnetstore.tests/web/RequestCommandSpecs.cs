using System;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.web.core;
using developwithpassion.bdd.mocking.rhino;

namespace nothinbutdotnetstore.tests.web
{
    public class RequestCommandSpecs
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<RequestCommand,
                                            DefaultRequestCommand> {

            context c = () =>
            {
                provide_a_basic_sut_constructor_argument<Predicate<Request>>(request1 => true);
            };
        }

        [Concern(typeof (DefaultRequestCommand))]
        public class when_determining_if_it_can_process_a_request : concern
        {

            because b = () =>
            {
                result = sut.can_handle(request);
            };


            it should_make_the_decision_by_using_its_request_criteria = () =>
            {
                result.should_be_true();
            };

            static bool result;
            static Request request;
        }

        [Concern(typeof (DefaultRequestCommand))]
        public class when_processing_a_request : concern
        {
            context c = () =>
            {
                app_command = the_dependency<ApplicationWebCommand>();
                request = an<Request>();
            };


            because b = () =>
            {
                sut.process(request);
            };


            it should_delegate_the_processing_to_the_application_web_command = () =>
            {
                app_command.received(command => command.process(request));
            };

            static Request request;
            static ApplicationWebCommand app_command;
        }
    }
}