using System;

namespace nothinbutdotnetstore.web.core.stubs
{
    public class StubViewRegistry : ViewRegistry
    {
        public string get_view_for<T>(T view_model)
        {
            return "~/View/DepartmentBrowser.aspx";
        }
    }
}