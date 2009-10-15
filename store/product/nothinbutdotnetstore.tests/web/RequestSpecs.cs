 using System;
 using System.Collections.Generic;
 using developwithpassion.bdd.contexts;
 using developwithpassion.bdd.harnesses.mbunit;
 using developwithpassion.bdddoc.core;
 using nothinbutdotnetstore.dto;
 using nothinbutdotnetstore.web.core;
 using Rhino.Mocks;

namespace nothinbutdotnetstore.tests.web
 {   
     public class RequestSpecs
     {
         public abstract class concern : observations_for_a_sut_with_a_contract<Request,
                                             DefaultRequest>
         {
        
         }

         [Concern(typeof(DefaultRequest))]
         public class when_a_request_is_asked_to_map_an_input_model : concern
         {
             context c = () =>
                             {
                                 value_to_map = "blah";
                                 mapped_value = value_to_map;
                                 input_mapping_registry = the_dependency<InputMappingRegistry>();
                                 request_info = the_dependency<RequestInfo>();
                                 input_mapper = an<InputMapper>();

                                 input_mapper.Stub(mapper => mapper.GetInputModel<string>(request_info)).Return(mapped_value);
                                 input_mapping_registry.Stub(registry => registry.create_mapping_for<string>()).Return(input_mapper);
                             };

             because b = () =>
                             {
                                 mapped_value = sut.map<string>();
                             };

        
             it should_return_an_instance_of_the_input_model = () =>
                        {
                            mapped_value.should_be_equal_to(value_to_map);
                        };

             private static InputMappingRegistry input_mapping_registry;
             private static string value_to_map;
             private static string mapped_value;
             private static InputMapper input_mapper;
             private static RequestInfo request_info;
         }
     }
 }
