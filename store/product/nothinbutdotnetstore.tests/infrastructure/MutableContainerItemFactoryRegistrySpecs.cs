 using System;
 using System.Collections.Generic;
 using developwithpassion.bdd.contexts;
 using developwithpassion.bdd.harnesses.mbunit;
 using developwithpassion.bdddoc.core;
 using nothinbutdotnetstore.infrastructure.containers;

namespace nothinbutdotnetstore.tests.infrastructure
 {   
     public class MutableContainerItemFactoryRegistrySpecs
     {
         public abstract class concern : observations_for_a_sut_with_a_contract<MutableContainerItemFactoryRegistry,
                                             DefaultContainerItemFactoryRegistry>
         {
        
         }

         [Concern(typeof(DefaultContainerItemFactoryRegistry))]
         public class when_a_container_item_factory_is_registered_for_the_type : concern
         {
             context c = () =>
                             {
                                 registry = new Dictionary<Type, ContainerItemFactory>();
                                 provide_a_basic_sut_constructor_argument(registry);

                             };

             because b = () =>
                             {
                                sut.register<string>(new FunctionalContainerItemFactory(() => "blah"));
                             };

        
             it should_contain_the_container_item_factory_for_the_specified_type = () =>
                        {
                            registry.ContainsKey(typeof (string));
            
            
                        };

             private static IDictionary<Type, ContainerItemFactory> registry;
         }
     }
 }
