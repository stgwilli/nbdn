 using System.Collections.Generic;
 using developwithpassion.bdd.contexts;
 using developwithpassion.bdd.harnesses.mbunit;
 using developwithpassion.bdd.mocking.rhino;
 using developwithpassion.bdddoc.core;
 using nothinbutdotnetstore.dto;
 using nothinbutdotnetstore.web.application;
 using nothinbutdotnetstore.web.core;
 using Rhino.Mocks;

namespace nothinbutdotnetstore.tests.web
 {   
     public class ResponseEngineSpecs
     {
         public abstract class concern : observations_for_a_sut_with_a_contract<ResponseEngine,
                                             DefaultResponseEngine>
         {
        
         }

         [Concern(typeof(DefaultResponseEngine))]
         public class when_processing_the_response : concern
         {
             context c = () =>
                             {
                                 payload = the_dependency<Payload>();
                                 view_registry = the_dependency<ViewRegistry>();
                                 routing_engine = the_dependency<RoutingEngine>();
                                 view = "blah";


                                 view_registry.Stub(x => x.get_view_for(departments)).Return(view);
                             };

             because b = () =>
                             {
                                sut.process(departments);
                             };

        
             it should_retrieve_the_correct_view_from_the_view_registry_based_on_the_dto = () =>
                {
                    view_registry.received(x => x.get_view_for(departments));
                };


             it should_store_the_viewmodel_in_the_payload_key = () =>
                {
                    payload.received(x => x.store(departments));
                };

             it should_pass_the_view_to_the_routing_engine = () =>
                 {
                     routing_engine.received(x => x.transfer(view));
                 };

             private static IEnumerable<Department> departments;
             private static ViewRegistry view_registry;
             private static Payload payload;
             private static RoutingEngine routing_engine;
             private static string view;
         }
     }
 }
