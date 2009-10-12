using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdddoc.core;
using nothinbutdotnetprep.infrastructure.extensions;

namespace nothinbutdotnetprep.tests
{
    public class IterationSpecs
    {
        public abstract class concern_for_iteration_extensions : observations_for_a_static_sut {}

        [Concern(typeof (Iteration))]
        public class when_iterating_through_a_range_of_numbers : concern_for_iteration_extensions
        {
            it should_visit_all_numbers = () =>
            {
                var numbers_visited = 0;
                foreach (var number in 1.to(2)) numbers_visited++;
                numbers_visited.should_be_equal_to(2);
            };
        }
    }
}