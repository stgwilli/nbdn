using System.Web;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultResponseEngine : ResponseEngine
    {
        ViewFactory view_factory;
        TransferBehaviour transfer_behaviour;

        public DefaultResponseEngine(ViewFactory view_factory):this(view_factory, 
            (handler, preserve) => HttpContext.Current.Server.Transfer(handler, preserve))
        {
        }

        public DefaultResponseEngine(ViewFactory view_factory, TransferBehaviour transfer_behaviour)
        {
            this.view_factory = view_factory;
            this.transfer_behaviour = transfer_behaviour;
        }

        public void process<ViewModel>(ViewModel model)
        {
            transfer_behaviour(view_factory.create_view_for(model), true);
        }
    }
}