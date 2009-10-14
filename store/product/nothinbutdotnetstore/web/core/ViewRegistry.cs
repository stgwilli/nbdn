namespace nothinbutdotnetstore.web.core
{
    public interface ViewRegistry
    {
        ViewForModel<ViewModel> get_view_for<ViewModel>();
    }
}