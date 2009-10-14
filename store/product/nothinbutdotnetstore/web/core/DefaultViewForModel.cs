using System;
using System.Web;
using System.Web.UI;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultViewForModel<ViewModel> : ViewForModel<ViewModel>
    {
        Page page;

        public DefaultViewForModel(Page page)
        {
            this.page = page;
        }

        public void ProcessRequest(HttpContext context)
        {
            page.ProcessRequest(context);
        }

        public bool IsReusable
        {
            get { return false; }
        }

        public ViewModel model
        {
            get; set;
        }
    }
}