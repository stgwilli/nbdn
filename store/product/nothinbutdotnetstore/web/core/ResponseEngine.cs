namespace nothinbutdotnetstore.web.core
{
    public interface ResponseEngine
    {
        void process<ViewModel>(ViewModel view_model);
    }
}