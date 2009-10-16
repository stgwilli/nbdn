using System;
using System.Collections.Generic;

namespace nothinbutdotnetstore.infrastructure.containers
{
    public class DefaultContainer : MutableContainer
    {
        MutableContainerItemFactoryRegistry registry;

        public DefaultContainer(MutableContainerItemFactoryRegistry registry)
        {
            this.registry = registry;
        }

        public Dependency instance_of<Dependency>()
        {
            return (Dependency) instance_of(typeof (Dependency));
        }

        public object instance_of(Type dependency_type)
        {
            try
            {
                return registry.get_resolution_item_for(dependency_type).create();
            }
            catch (Exception exception)
            {
                throw new ContainerItemResolutionException(exception, dependency_type);
            }
        }

        public IEnumerable<DependencyType> all_instances_of<DependencyType>()
        {
            throw new NotImplementedException();
        }

        public void register<T>(ContainerItemFactory factory)
        {
            registry.register<T>(factory);
        }

        public void register<T>(T item)
        {
            registry.register<T>(new FunctionalContainerItemFactory(() => item));
        }
    }
}