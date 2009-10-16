using System;

namespace nothinbutdotnetstore.infrastructure.containers
{
    public class FunctionalContainerItemFactory : ContainerItemFactory
    {
        Func<object> type_creator;

        public FunctionalContainerItemFactory(Func<object> type_creator)
        {
            this.type_creator = type_creator;
        }

        public object create()
        {
            return type_creator();
        }
    }
}