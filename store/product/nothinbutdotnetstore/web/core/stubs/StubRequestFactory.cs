using System;
using System.Web;

namespace nothinbutdotnetstore.web.core.stubs
{
    public class StubRequestFactory : RequestFactory
    {
        class StubRequest : Request {
            public InputModel map<InputModel>()
            {
                throw new NotImplementedException();
            }

            public Uri uri { get; set; }
        }

        public Request create_from(HttpContext http_context)
        {
            return new StubRequest(){uri = http_context.Request.Url};
        }
    }
}