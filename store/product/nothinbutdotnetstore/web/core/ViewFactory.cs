namespace nothinbutdotnetstore.web.core
{
    public interface ViewFactory
    {
        ViewForModel<ViewModel> create_view_for<ViewModel>(ViewModel model);
    }
}