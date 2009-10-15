namespace nothinbutdotnetstore.web.core
{
    public class DefaultRequest : Request
    {
        MapperRegistry input_mapping_registry;
        RequestInfo request_info;

        public DefaultRequest(MapperRegistry input_mapping_registry, string url,RequestInfo request_info)
        {
            this.input_mapping_registry = input_mapping_registry;
            this.request_info = request_info;
            this.url = url;
        }

        public InputModel map<InputModel>()
        {
            return input_mapping_registry.get_mapper_for<RequestInfo, InputModel>().map(request_info);
        }

        public string url
        {
            get; set;
        }
    }
}