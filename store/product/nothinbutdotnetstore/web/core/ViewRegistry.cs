namespace nothinbutdotnetstore.web.core
{
    public interface ViewRegistry
    {
        string get_view_for<T>(T view_model);
    }
}