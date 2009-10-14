using System;
using System.IO;
using System.Web;

namespace nothinbutdotnetstore.tests.utility
{
    public class ObjectMother
    {
        static public HttpContext create_http_context()
        {
            return new HttpContext(create_request(), create_response());
        }

        static HttpResponse create_response()
        {
            return new HttpResponse(new StringWriter());
        }

        static HttpRequest create_request()
        {
            return new HttpRequest("blah.aspx", "http://www.blah/blah.aspx", String.Empty);
        }
    }
}