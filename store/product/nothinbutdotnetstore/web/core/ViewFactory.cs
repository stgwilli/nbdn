namespace nothinbutdotnetstore.web.core
{
    public interface ViewFactory
    {
        ViewForModel<ViewModel> get_view_for<ViewModel>(ViewModel model);
    }
}