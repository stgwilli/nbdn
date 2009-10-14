namespace nothinbutdotnetstore.web.core
{
    public interface View<T>
    {
        void display(T data);
    }
}