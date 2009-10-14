namespace nothinbutdotnetstore.web.core
{
    public interface RequestCommand : ApplicationWebCommand
    {
        bool can_handle(Request request);
    }
}