namespace nothinbutdotnetstore.web.core
{
    public delegate ViewModel ViewQuery<ViewModel>(Request request);

    public class ViewCommand<ViewModel> : ApplicationWebCommand
    {
        ResponseEngine response_engine;
        ViewQuery<ViewModel> get_view_model;

        public ViewCommand(ResponseEngine response_engine, ViewQuery<ViewModel> get_view_model)
        {
            this.get_view_model = get_view_model;
            this.response_engine = response_engine;
        }

        public void process(Request request)
        {
            response_engine.process(get_view_model(request));
        }
    }
}