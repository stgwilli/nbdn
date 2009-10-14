using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdd.mocking.rhino;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.web.core;
using Rhino.Mocks;

namespace nothinbutdotnetstore.tests.web
{
    public class FrontControllerSpecs
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<FrontController,
                                            DefaultFrontController> {}

        [Concern(typeof (DefaultFrontController))]
        public class when_processing_a_request : concern
        {
            context c = () =>
            {
                request = an<Request>();
                command_that_can_process = an<RequestCommand>();
                command_registry = the_dependency<CommandRegistry>();

                command_registry.Stub(registry => registry.get_command_that_can_process(request)).Return(command_that_can_process);
            };

            because b = () =>
            {
                sut.process(request);
            };


            it should_tell_the_command_that_can_process_the_request_to_run = () =>
            {
                command_that_can_process.received(x => x.process(request));
            };

            static RequestCommand command_that_can_process;
            static Request request;
            static CommandRegistry command_registry;
        }
    }
}