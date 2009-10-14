namespace nothinbutdotnetstore.web.core
{
    public interface RequestCommand
    {
        void process(Request request);
        bool can_handle(Request request);
    }
}