using System.Data;
using System.Linq;
using System.Reflection;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdddoc.core;
using nothinbutdotnetprep.infrastructure.extensions;

namespace nothinbutdotnetprep.tests
{
    public class TypeExtensionsSpecs
    {
        public abstract class concern : observations_for_a_static_sut {}

        [Concern(typeof (TypeExtensions))]
        public class when_a_type_is_told_to_find_its_greediest_constructor : observations_for_a_static_sut
        {
            static ConstructorInfo result;

            because b = () =>
            {
                result = typeof (SomethingWithConstructors).greediest_constructor();
            };

            it should_return_the_constructor_that_takes_the_most_arguments = () =>
            {
                result.GetParameters().Count().should_be_equal_to(2);
            };
        }

        public class SomethingWithConstructors
        {
            public IDbConnection connection { get; set; }

            public IDbCommand command { get; set; }

            public SomethingWithConstructors(IDbConnection connection) {}

            public SomethingWithConstructors(IDbConnection connection, IDbCommand command)
            {
                this.connection = connection;
                this.command = command;
            }
        }
    }
}