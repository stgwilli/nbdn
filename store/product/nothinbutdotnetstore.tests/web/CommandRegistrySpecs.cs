using System.Collections.Generic;
using System.Linq;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.core.extensions;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.web.core;
using Rhino.Mocks;

namespace nothinbutdotnetstore.tests.web
{
    public class CommandRegistrySpecs
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<CommandRegistry,
                                            DefaultCommandRegistry>
        {
            context c = () =>
            {
                request = an<Request>();
                list_of_all_commands = new List<RequestCommand>();
                provide_a_basic_sut_constructor_argument<IEnumerable<RequestCommand>>(list_of_all_commands);
            };

            static protected IList<RequestCommand> list_of_all_commands;
            static protected Request request;
        }


        [Concern(typeof (DefaultCommandRegistry))]
        public class when_getting_a_command_for_a_request_and_it_has_the_command : concern
        {
            context c = () =>
            {
                command_that_can_process = an<RequestCommand>();
                list_of_all_commands.Add(an<RequestCommand>());
                list_of_all_commands.Add(command_that_can_process);
                command_that_can_process.Stub(command => command.can_handle(request)).Return(true);
            };

            because b = () =>
            {
                result = sut.get_command_that_can_process(request);
            };


            it should_return_the_command_that_can_process_the_request = () =>
            {
                result.should_be_equal_to(command_that_can_process);
            };

            static RequestCommand result;
            static RequestCommand command_that_can_process;
        }

        public class when_getting_a_command_for_a_request_and_there_is_no_command_that_can_handle_it : concern
        {
            context c = () =>
            {
                Enumerable.Range(1, 100).each(i => list_of_all_commands.Add(an<RequestCommand>()));
            };

            because b = () =>
            {
                result = sut.get_command_that_can_process(request);
            };

            it should_return_a_missing_command = () =>
            {
                result.should_be_an_instance_of<MissingRequestCommand>();
            };

            static RequestCommand result;
        }
    }
}