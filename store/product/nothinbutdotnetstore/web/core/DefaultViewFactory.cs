using System;
using System.Web.UI;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultViewFactory : ViewFactory
    {
        public ViewForModel<ViewModel> get_view_for<ViewModel>(ViewModel model)
        {
            var view_page =(Page)System.Web.Compilation.BuildManager.CreateInstanceFromVirtualPath("~/views/DepartmentBrowser.aspx",typeof (Page));
            var view_for_model = new DefaultViewForModel<ViewModel>(view_page) {model = model};

            return view_for_model;
            
        }
    }
}