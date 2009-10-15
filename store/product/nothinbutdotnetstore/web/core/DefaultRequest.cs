using System;
using System.Collections.Generic;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultRequest : Request
    {
        private readonly InputMappingRegistry input_mapping_registry;

        public DefaultRequest(InputMappingRegistry input_mapping_registry, RequestInfo request_info)
        {
            this.input_mapping_registry = input_mapping_registry;
            this.request_info = request_info;
        }

        public InputModel map<InputModel>()
        {
            return input_mapping_registry.create_mapping_for<InputModel>().GetInputModel<InputModel>(request_info);
        }

        public RequestInfo request_info { get; private set; }
    }
}