 using System;
 using System.Collections.Generic;
 using developwithpassion.bdd.contexts;
 using developwithpassion.bdd.harnesses.mbunit;
 using developwithpassion.bdddoc.core;
 using nothinbutdotnetstore.infrastructure.containers;
 using Rhino.Mocks;

namespace nothinbutdotnetstore.tests.infrastructure
 {   
     public class ContainerItemFactoryRegistrySpecs
     {
         public abstract class concern : observations_for_a_sut_with_a_contract<ContainerItemFactoryRegistry,
                                             DefaultContainerItemFactoryRegistry>
         {
        
         }

         [Concern(typeof(DefaultContainerItemFactoryRegistry))]
         public class when_resolving_a_known_type : concern
         {
             context c = () =>
             {
                 the_type = typeof (string);
                 container_item_factory = an<ContainerItemFactory>();
                 factory_dictionary = the_dependency<IDictionary<Type, ContainerItemFactory>>();
                 factory_dictionary[the_type] = container_item_factory;                 
             };

             because b = () =>
             {
                  returned_item_factory = sut.get_resolution_item_for(the_type);
             };
        
             it should_return_the_container_item_factory_for_that_type = () =>
             {                            
                 returned_item_factory.should_be_equal_to(container_item_factory);
             };

             static ContainerItemFactory returned_item_factory;
             static ContainerItemFactory container_item_factory;
             static IDictionary<Type, ContainerItemFactory> factory_dictionary;
             static Type the_type;
         }

         [Concern(typeof(DefaultContainerItemFactoryRegistry))]
         public class when_resolving_an_unknown_type : concern
         {
             context c = () =>
             {
                 missing_container_item_factory = an<MissingContainerItemFactory>();
                 provide_a_basic_sut_constructor_argument(new Dictionary<Type, ContainerItemFactory>());
             };

             because b = () =>
             {
                 returned_item_factory = sut.get_resolution_item_for(typeof(string));
             };

             it should_return_the_missing_container_item_factory = () =>
             {
                 returned_item_factory.should_be_an_instance_of<MissingContainerItemFactory>();
             };

             static ContainerItemFactory returned_item_factory;
             static MissingContainerItemFactory missing_container_item_factory;
             static IDictionary<Type, ContainerItemFactory> factory_dictionary;
         }
     }
 }
