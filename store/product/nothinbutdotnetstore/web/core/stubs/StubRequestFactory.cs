using System;
using System.Web;

namespace nothinbutdotnetstore.web.core.stubs
{
    public class StubRequestFactory : RequestFactory
    {
        public Request create_from(HttpContext http_context)
        {
            return new StubRequest();
        }

        class StubRequest : Request {
            public InputModel map<InputModel>()
            {
                throw new NotImplementedException();
            }

            public RequestInfo request_info { get; private set; }
        }
    }
}