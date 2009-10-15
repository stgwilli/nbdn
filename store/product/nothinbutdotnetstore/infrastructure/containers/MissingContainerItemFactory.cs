using System;

namespace nothinbutdotnetstore.infrastructure.containers
{
    public class MissingContainerItemFactory : ContainerItemFactory
    {
        public object create()
        {
            throw new NotImplementedException();
        }
    }
}
