using System.Collections.Generic;
using System.Linq;
using nothinbutdotnetstore.web.application;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultCommandRegistry : CommandRegistry
    {
        IEnumerable<RequestCommand> commands;

        public DefaultCommandRegistry():this(create_basic_commands()) {}

        static IEnumerable<RequestCommand> create_basic_commands()
        {
            var li = new List<RequestCommand>
                         {
                             new DefaultRequestCommand(Url.contains("ViewMainDepartments"),
                                                       Actions.ViewMainDepartments),
                             new DefaultRequestCommand(x => x.url.PathAndQuery.StartsWith("ViewSubDepartments"),
                                                       Actions.ViewSubDepartments),
                             new DefaultRequestCommand(x => x.url.PathAndQuery.StartsWith("ViewProducts"),
                                                       Actions.ViewProductsInDerpartments)
                         };

            return li;
        }

        public DefaultCommandRegistry(IEnumerable<RequestCommand> commands)
        {
            this.commands = commands;
        }

        public RequestCommand get_command_that_can_process(Request request)
        {
            return commands.FirstOrDefault(command => command.can_handle(request)) ?? new MissingRequestCommand();
        }
    }
}