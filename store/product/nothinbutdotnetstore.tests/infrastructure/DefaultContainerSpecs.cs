using System.Data;
using System.Data.SqlClient;
using developwithpassion.bdd.contexts;
using developwithpassion.bdd.harnesses.mbunit;
using developwithpassion.bdddoc.core;
using developwithpassion.commons.core.infrastructure.containers;
using nothinbutdotnetstore.infrastructure.containers;
using Rhino.Mocks;

namespace nothinbutdotnetstore.tests.infrastructure
{
    public class DefaultContainerSpecs
    {
        public abstract class concern : observations_for_a_sut_with_a_contract<Container,
                                            DefaultContainer> {}

        [Concern(typeof (DefaultContainer))]
        public class when_resolving_an_instance_of_an_contract : concern
        {
            context c = () =>
            {
                sql_connection = new SqlConnection();
                connection_container_item_factory = an<ContainerItemFactory>();
                container_item_factory_registry = the_dependency<ContainerItemFactoryRegistry>();


                connection_container_item_factory.Stub(item => item.create()).Return(sql_connection);
                container_item_factory_registry.Stub(registry => registry.get_resolution_item_for(typeof (IDbConnection))).Return(connection_container_item_factory);

            };

            because b = () =>
            {
                result = sut.instance_of<IDbConnection>();
            };


            it should_return_the_instance_resolved_by_the_types_item_factory = () =>
            {
                result.should_be_equal_to(sql_connection);
            };

            static IDbConnection result;
            static SqlConnection sql_connection;
            static ContainerItemFactory connection_container_item_factory;
            static ContainerItemFactoryRegistry container_item_factory_registry;
        }
    }
}