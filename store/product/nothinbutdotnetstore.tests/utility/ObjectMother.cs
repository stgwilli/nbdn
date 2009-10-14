using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using nothinbutdotnetstore.web.core;
using System.Linq;

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

        static public IEnumerable<T> create_enumerable_from<T>(params T[] items)
        {
            return items.Select(item => item);
        }
    }
}