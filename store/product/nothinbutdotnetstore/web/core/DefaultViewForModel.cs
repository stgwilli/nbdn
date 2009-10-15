using System.Web.UI;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultViewForModel<ViewModel> : Page, ViewForModel<ViewModel>
    {
        public ViewModel model { get; set; }
    }
}