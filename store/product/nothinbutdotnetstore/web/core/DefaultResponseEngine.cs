using System;
using System.Web;
using nothinbutdotnetstore.web.application;
using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultResponseEngine : ResponseEngine
    {
        ViewRegistry view_registry;
        TransferBehaviour transfer_behaviour;

        public DefaultResponseEngine(ViewRegistry view_registry):this(view_registry, 
            (handler, preserve) => HttpContext.Current.Server.Transfer(handler, preserve))
        {
        }

        public DefaultResponseEngine(ViewRegistry view_registry, TransferBehaviour transfer_behaviour)
        {
            this.view_registry = view_registry;
            this.transfer_behaviour = transfer_behaviour;
        }

        public void process<ViewModel>(ViewModel model)
        {
            var view = view_registry.get_view_for<ViewModel>();
            view.model = model;
            transfer_behaviour(view, true);
        }
    }
}