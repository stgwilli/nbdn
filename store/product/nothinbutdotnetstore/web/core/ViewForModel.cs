using System.Web;

namespace nothinbutdotnetstore.web.core
{
    public interface ViewForModel<Model> : IHttpHandler
    {
        Model model { get; set; }
    }
}