using System.Web;
using nothinbutdotnetstore.web.application;

namespace nothinbutdotnetstore.web.core
{
    public class StubResponseEngine : ResponseEngine
    {
        public void process<ViewModel>(ViewModel model)
        {
            //HttpContext.Current.Items.Add(Keys.ViewModels.departments, model);
            //HttpContext.Current.Server.Transfer("~/views/DepartmentBrowser.aspx");
        }
    }
}