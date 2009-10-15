using System;

namespace nothinbutdotnetstore.infrastructure.containers
{
    public class ContainerItemResolutionException : Exception
    {
        public ContainerItemResolutionException(Exception innerException, Type type_that_could_not_be_resolved) 
            : base(String.Format("Type {0} could not be resolved.", type_that_could_not_be_resolved.Name), innerException)
        {
            this.type_that_could_not_be_resolved = type_that_could_not_be_resolved;
        }

        public Type type_that_could_not_be_resolved { get; private set; }
    }
}