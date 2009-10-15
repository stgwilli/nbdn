using System;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultRequest : Request
    {
        MapperRegistry input_mapping_registry;
        RequestInfo request_info;
        private Uri uri;

        public DefaultRequest(MapperRegistry input_mapping_registry, RequestInfo request_info, Uri uri)
        {
            this.input_mapping_registry = input_mapping_registry;
            this.request_info = request_info;
            this.uri = uri;
        }

        public InputModel map<InputModel>()
        {
            return input_mapping_registry.get_mapper_for<RequestInfo, InputModel>()
                .map(request_info);
        }

        public Uri Uri
        {
            get { return uri; }
        }

    }
}