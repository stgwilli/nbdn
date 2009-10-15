using System;

namespace nothinbutdotnetstore.infrastructure.containers
{
    public class StrategyContainerItemFactory<ImplementationType> : ContainerItemFactory
    {
        private Func<ImplementationType> type_creator;

        public StrategyContainerItemFactory(Func<ImplementationType> type_creator)
        {
            this.type_creator = type_creator;
        }

        public object create()
        {
            return type_creator();
        }
    }
}