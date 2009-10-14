namespace nothinbutdotnetstore.web.core
{
    public interface ViewRegistry
    {
        string get_view_path_for<ViewModel>();
    }
}