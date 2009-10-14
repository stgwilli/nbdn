using System;
using System.Collections.Generic;
using System.Linq;
using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.tasks.stubs;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultCommandRegistry : CommandRegistry
    {
        IEnumerable<RequestCommand> commands;

        public DefaultCommandRegistry():this(create_basic_commands()) {}

        static IEnumerable<RequestCommand> create_basic_commands()
        {
            //throw new NotImplementedException();
            CatalogTasks ct = new StubCatalogTasks();
            ResponseEngine re = new DefaultResponseEngine();
            var pr = new Predicate<Request>(x => true);

            ApplicationWebCommand awc = new ViewMainDepartments(ct,re);
            RequestCommand drc = new DefaultRequestCommand(pr,awc);

            List<RequestCommand> li = new List<RequestCommand>();
            li.Add(drc);
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