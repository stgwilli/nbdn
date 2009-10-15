namespace nothinbutdotnetstore.web.core
{
    public interface Mapper<Input,Output>
    {
        Output map(Input item);
    }
}