namespace nothinbutdotnetstore.web.core
{
    public interface InputMapper
    {
        InputModel GetInputModel<InputModel>(RequestInfo request_info);
    }
}