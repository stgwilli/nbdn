using System;
using System.Web;
using nothinbutdotnetstore.web.application;
using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultResponseEngine : ResponseEngine
    {
        ViewFactory _viewFactory;
        TransferBehaviour transfer_behaviour;

        public DefaultResponseEngine(ViewFactory _viewFactory):this(_viewFactory, 
            (handler, preserve) => HttpContext.Current.Server.Transfer(handler, preserve))
        {
        }

        public DefaultResponseEngine(ViewFactory _viewFactory, TransferBehaviour transfer_behaviour)
        {
            this._viewFactory = _viewFactory;
            this.transfer_behaviour = transfer_behaviour;
        }

        public void process<ViewModel>(ViewModel model)
        {
            var view = _viewFactory.get_view_for(model);
            transfer_behaviour(view, true);
        }
    }
}