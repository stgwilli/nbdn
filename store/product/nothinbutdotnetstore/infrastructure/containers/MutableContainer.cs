using developwithpassion.commons.core.infrastructure.containers;

namespace nothinbutdotnetstore.infrastructure.containers
{
    public interface MutableContainer : Container
    {
        void register<T>(ContainerItemFactory factory);
        void register<T>(T item);
    }
}