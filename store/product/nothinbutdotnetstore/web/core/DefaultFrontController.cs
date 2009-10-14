namespace nothinbutdotnetstore.web.core
{
    public class DefaultFrontController : FrontController
    {
        CommandRegistry commmand_registry;

        public DefaultFrontController():this(new DefaultCommandRegistry()) {}

        public DefaultFrontController(CommandRegistry commmand_registry)
        {
            this.commmand_registry = commmand_registry;
        }

        public void process(Request request)
        {
            commmand_registry.get_command_that_can_process(request).process(request);
        }
    }
}