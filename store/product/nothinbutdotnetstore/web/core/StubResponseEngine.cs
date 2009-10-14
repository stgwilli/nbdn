using System.Web;
using nothinbutdotnetstore.web.application;

namespace nothinbutdotnetstore.web.core
{
    public class StubResponseEngine : ResponseEngine
    {
        public void process<ViewModel>(ViewModel view_model)
        {
            HttpContext.Current.Items.Add(Keys.ViewModels.departments, view_model);
            HttpContext.Current.Server.Transfer("~/views/DepartmentBrowser.aspx");
        }
    }
}