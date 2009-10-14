using System;
using System.Collections.Generic;

namespace nothinbutdotnetstore.web.core
{
    public interface ResponseEngine
    {
        void process<ViewModel>(ViewModel view_model);
    }

    public class DefaultResponseEngine : ResponseEngine {
        public DefaultResponseEngine()
        {

        }
        public void process<ViewModel>(ViewModel view_model)
        {
            System.Web.HttpContext.Current.Items.Add("ViewModel", view_model);
            System.Web.HttpContext.Current.Server.Transfer("~/views/DepartmentBrowser.aspx");
        }
    }
}