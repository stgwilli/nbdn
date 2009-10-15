using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdddoc.core;
using nothinbutdotnetprep.infrastructure.sorting;

namespace nothinbutdotnetprep.tests
{
    public class FixedComparerSpecs
    {
        public abstract class concern : observations_for_a_sut_without_a_contract<FixedComparer<Person, int>> {}

        [Concern(typeof (FixedComparer<,>))]
        public class when_comparing_a_set_of_items_and_there_have_been_no_fixed_items : concern
        {
            context c = () =>
            {
                jp = new Person {age = 29};
                aaron = new Person {age = 31};
            };

            because b = () =>
            {
                result = sut.Compare(aaron,jp);
            };


            it should_return_the_comparison_of_the_values = () =>
            {
                result.should_be_greater_than(0);
            };

            static int result;
            static Person jp;
            static Person aaron;
        }
    }

    public class Person
    {
        public int age { get; set; }
    }
}