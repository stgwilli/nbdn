using System.Web;

namespace nothinbutdotnetstore.web.core
{
    public interface RequestFactory
    {
        object create_from(HttpContext http_context);
    }
}