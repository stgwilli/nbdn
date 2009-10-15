using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.web.core;
using Rhino.Mocks;

namespace nothinbutdotnetstore.tests.web
{
    public class RequestSpecs
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<Request,
                                            DefaultRequest> {}

        [Concern(typeof (DefaultRequest))]
        public class when_a_request_is_asked_to_map_an_input_model : concern
        {
            context c = () =>
            {
                value_to_map = "blah";
                mapped_value = value_to_map;
                input_mapping_registry = the_dependency<MapperRegistry>();
                request_info = the_dependency<RequestInfo>();
                input_mapper = an<Mapper<RequestInfo,string>>();

                input_mapper.Stub(mapper => mapper.map(request_info)).Return(mapped_value);
                input_mapping_registry.Stub(registry => registry.get_mapper_for<RequestInfo,string>()).Return(input_mapper);

                provide_a_basic_sut_constructor_argument("blah");
            };

            because b = () =>
            {
                mapped_value = sut.map<string>();
            };


            it should_return_the_model_mapped_from_the_model_mapper = () =>
            {
                mapped_value.should_be_equal_to(value_to_map);
            };

            static MapperRegistry input_mapping_registry;
            static string value_to_map;
            static string mapped_value;
            static Mapper<RequestInfo,string> input_mapper;
            static RequestInfo request_info;

        }
    }
}