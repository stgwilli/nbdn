using System;
using System.Web;

namespace nothinbutdotnetstore.web.core
{
    public interface RequestFactory
    {
        Request create_from(Uri uri);
    }

    public class DefaultRequestFactory : RequestFactory
    {
        public Request create_from(HttpContext http_context)
        {

        }
    }
}