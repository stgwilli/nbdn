using System.Web.UI;

namespace nothinbutdotnetstore.web.core
{
    public class ViewPage<ViewModel> : Page
    {
        public ViewModel Model { get; set; }
    }
}