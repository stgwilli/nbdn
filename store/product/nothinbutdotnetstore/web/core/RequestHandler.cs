using System.Web;
using developwithpassion.commons.core.infrastructure.containers;
using developwithpassion.commons.core.infrastructure.logging;

namespace nothinbutdotnetstore.web.core
{
    public class RequestHandler : IHttpHandler
    {
        FrontController front_controller;
        RequestFactory request_factory;

        public RequestHandler() : this(IOC.resolve.instance_of<FrontController>(),
                                       IOC.resolve.instance_of<RequestFactory>()) {}

        public RequestHandler(FrontController front_controller, RequestFactory request_factory)
        {
            this.front_controller = front_controller;
            this.request_factory = request_factory;
        }

        public void ProcessRequest(HttpContext context)
        {
            front_controller.process(request_factory.create_from(context));
        }

        public bool IsReusable
        {
            get { return true; }
        }
    }
}