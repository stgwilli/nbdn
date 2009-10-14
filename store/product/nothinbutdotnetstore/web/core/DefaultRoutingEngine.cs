using System.Web;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultRoutingEngine : RoutingEngine
    {
        public void transfer(string view)
        {
            HttpContext.Current.Server.Transfer(view);
        }
    }
}