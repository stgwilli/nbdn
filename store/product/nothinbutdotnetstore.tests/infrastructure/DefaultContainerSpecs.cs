using System;
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
                                            DefaultContainer>
        {
            context c = () =>
            {
                container_item_factory_registry = the_dependency<ContainerItemFactoryRegistry>();
            };

            static protected ContainerItemFactoryRegistry container_item_factory_registry;
        }

        [Concern(typeof (DefaultContainer))]
        public class when_resolving_an_instance_of_an_contract : concern
        {
            context c = () =>
            {
                sql_connection = new SqlConnection();
                connection_container_item_factory = an<ContainerItemFactory>();


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
        }

        [Concern(typeof (DefaultContainer))]
        public class when_resolving_an_dependency_and_the_container_item_factory_throws_an_error_while_creating_the_dependency : concern
        {
            context c = () =>
            {
                original_exception = new Exception();
                connection_container_item_factory = an<ContainerItemFactory>();
                container_item_factory_registry.Stub(registry => registry.get_resolution_item_for(typeof (IDbConnection)))
                    .Return(connection_container_item_factory);

                connection_container_item_factory.Stub(factory => factory.create()).Throw(original_exception);
            };

            because b = () =>
            {
                doing(() => sut.instance_of<IDbConnection>());
            };

            it should_throw_a_resolution_exception_that_provides_access_to_the_underlying_exception_and_the_type_that_could_not_be_resolved = () =>
            {
                var thrown_exception = exception_thrown_by_the_sut.should_be_an_instance_of<ContainerItemResolutionException>();
                thrown_exception.InnerException.should_be_equal_to(original_exception);
                thrown_exception.type_that_could_not_be_resolved.should_be_equal_to(typeof (IDbConnection));
            };


            static IDbConnection result;
            static ContainerItemFactory connection_container_item_factory;
            static Exception original_exception;
        }

        [Concern(typeof (DefaultContainer))]
        public class when_resolving_an_instance_of_an_contract_using_a_type : concern
        {
            context c = () =>
            {
                sql_connection = new SqlConnection();
                connection_container_item_factory = an<ContainerItemFactory>();


                connection_container_item_factory.Stub(item => item.create()).Return(sql_connection);
                container_item_factory_registry.Stub(registry => registry.get_resolution_item_for(typeof (IDbConnection))).Return(connection_container_item_factory);
            };

            because b = () =>
            {
                result = sut.instance_of(typeof (IDbConnection));
            };


            it should_return_the_instance_resolved_by_the_types_item_factory = () =>
            {
                result.should_be_equal_to(sql_connection);
            };

            static object result;
            static SqlConnection sql_connection;
            static ContainerItemFactory connection_container_item_factory;
        }
    }
}