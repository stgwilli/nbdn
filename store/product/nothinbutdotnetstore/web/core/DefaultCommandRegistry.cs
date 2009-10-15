using System;
using System.Collections.Generic;
using System.Linq;
using nothinbutdotnetstore.tasks.stubs;
using nothinbutdotnetstore.web.application;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultCommandRegistry : CommandRegistry
    {
        IEnumerable<RequestCommand> commands;

        public DefaultCommandRegistry():this(create_basic_commands()) {}

        static IEnumerable<RequestCommand> create_basic_commands()
        {
            var ct = new StubCatalogBrowsingTasks();
            var re = new DefaultResponseEngine(new DefaultViewFactory());
            var pr = new Predicate<Request>(x => true);

            var awc = new ViewMainDepartments(ct,re);
            var drc = new DefaultRequestCommand(pr,awc);

            var li = new List<RequestCommand>();
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