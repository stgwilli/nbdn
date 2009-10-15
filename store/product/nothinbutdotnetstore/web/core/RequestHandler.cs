using System.Web;
using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.web.core
{
    public class RequestHandler : IHttpHandler
    {
        FrontController front_controller;
        RequestFactory request_factory;

        public RequestHandler():this(new DefaultFrontController(),new StubRequestFactory()) {}

        public RequestHandler(FrontController front_controller, RequestFactory request_factory)
        {
            this.front_controller = front_controller;
            this.request_factory = request_factory;
        }

        public void ProcessRequest(HttpContext context)
        {
            front_controller.process(request_factory.create_from(context.Request.Url));
        }

        public bool IsReusable
        {
            get { return true;}
        }
    }
}