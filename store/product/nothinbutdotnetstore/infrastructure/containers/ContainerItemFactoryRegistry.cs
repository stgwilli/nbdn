using System;

namespace nothinbutdotnetstore.infrastructure.containers
{
    public interface ContainerItemFactoryRegistry
    {
        ContainerItemFactory get_resolution_item_for(Type type);
    }
}