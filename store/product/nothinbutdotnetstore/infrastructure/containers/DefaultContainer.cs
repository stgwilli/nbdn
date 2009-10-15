using System;
using System.Collections.Generic;
using developwithpassion.commons.core.infrastructure.containers;

namespace nothinbutdotnetstore.infrastructure.containers
{
    public class DefaultContainer : Container
    {
        public Dependency instance_of<Dependency>()
        {
            throw new NotImplementedException();
        }

        public object instance_of(Type dependency_type)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DependencyType> all_instances_of<DependencyType>()
        {
            throw new NotImplementedException();
        }
    }
}