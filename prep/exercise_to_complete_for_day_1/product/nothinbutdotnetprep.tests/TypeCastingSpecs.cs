using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdddoc.core;
using nothinbutdotnetprep.infrastructure.extensions;

namespace nothinbutdotnetprep.tests
{
    public class TypeCastingSpecs
    {
        public abstract class concern : observations_for_a_static_sut {}

        [Concern(typeof (TypeCasting))]
        public class when_a_legitimate_downcast_is_made : concern
        {
            it should_retrieve_the_object_back_downcasted_to_the_target_type = () =>
            {
                IList<int> list = new List<int>();
                var to = list.downcast_to<List<int>>();
            };
        }

        [Concern(typeof (TypeCasting))]
        public class when_asking_if_an_object_is_not_an_instance_of_a_specific_type : concern
        {
            it should_be_true_if_the_object_is_not_an_instance_of_the_specified_type = () =>
            {
                new SqlConnection().is_not_a<IDbCommand>().should_be_true();
            };

            it should_be_false_if_the_object_is_an_instance_of_the_specified_type = () =>
            {
                new SqlConnection().is_not_a<IDbConnection>().should_be_false();
            };
        }
    }
}