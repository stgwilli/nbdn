namespace nothinbutdotnetstore.web.application
{
    public interface Payload
    {
        void store<T>(T view_model);

        T retrieve<T>();
    }
}