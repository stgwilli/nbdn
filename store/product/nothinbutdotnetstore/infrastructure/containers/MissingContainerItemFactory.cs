using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
