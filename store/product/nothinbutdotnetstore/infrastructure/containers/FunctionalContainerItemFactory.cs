using System;

namespace nothinbutdotnetstore.infrastructure.containers
{
    public class FunctionalContainerItemFactory<ImplementationType> : ContainerItemFactory
    {
        Func<ImplementationType> type_creator;

        public FunctionalContainerItemFactory(Func<ImplementationType> type_creator)
        {
            this.type_creator = type_creator;
        }

        public object create()
        {
            return type_creator();
        }
    }
}