using System;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultRequest : Request
    {
        MapperRegistry input_mapping_registry;

        public DefaultRequest(MapperRegistry input_mapping_registry, string url)
        {
            this.input_mapping_registry = input_mapping_registry;
            this.url = url;
        }

        public InputModel map<InputModel>()
        {
            return input_mapping_registry.get_mapper_for<string, InputModel>().map(url);
        }

        public string url
        {
            get; set;
        }
    }
}