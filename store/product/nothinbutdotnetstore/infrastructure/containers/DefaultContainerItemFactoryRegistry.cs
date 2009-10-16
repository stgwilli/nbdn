using System;
using System.Collections.Generic;

namespace nothinbutdotnetstore.infrastructure.containers
{
    public class DefaultContainerItemFactoryRegistry : MutableContainerItemFactoryRegistry
    {
        IDictionary<Type, ContainerItemFactory> container_item_factories;

        public DefaultContainerItemFactoryRegistry(IDictionary<Type, ContainerItemFactory> container_item_factories)
        {
            this.container_item_factories = container_item_factories;
        }

        public ContainerItemFactory get_resolution_item_for(Type type)
        {
            return container_item_factories.ContainsKey(type)
                       ? container_item_factories[type]
                       : new MissingContainerItemFactory();
        }

        public void register<T>(ContainerItemFactory factory)
        {
            container_item_factories.Add(typeof(T), factory);
        }
    }
}
