namespace nothinbutdotnetstore.web.core
{
    public interface InputMappingRegistry
    {
        InputMapper create_mapping_for<InputModel>();
    }
}