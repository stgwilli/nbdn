namespace nothinbutdotnetstore.web.core.stubs
{
    public class StubViewRegistry : ViewRegistry
    {
        public string get_view_path_for<ViewModel>()
        {
            return "~/views/departmentbrowser.aspx";
        }
    }
}