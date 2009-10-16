using System;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdddoc.core;
using nothinbutdotnetstore.infrastructure.containers;

namespace nothinbutdotnetstore.tests.infrastructure
{
    public class ContainerItemFactorySpecs
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<ContainerItemFactory,
                                            FunctionalContainerItemFactory> {}

        [Concern(typeof (FunctionalContainerItemFactory))]
        public class when_creating_an_item_that_it_can_create : concern
        {
            context c = () =>
            {
                strategy = () => "blah";
                object_to_check_for = "blah";

                provide_a_basic_sut_constructor_argument(strategy);
            };

            because b = () =>
            {
                returned_type = sut.create();
            };


            it should_create_an_item = () =>
            {
                returned_type.should_be_equal_to(object_to_check_for);
            };

            static string object_to_check_for;
            static object returned_type;
            static Func<object> strategy;
        }
    }
}