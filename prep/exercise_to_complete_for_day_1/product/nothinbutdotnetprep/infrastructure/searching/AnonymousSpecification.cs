using System;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class AnonymousSpecification<T> : Specification<T>
    {
        readonly Predicate<T> predicate;

        public AnonymousSpecification(Predicate<T> predicate)
        {
            this.predicate = predicate;
        }

        public bool is_satisfied_by(T item)
        {
            return predicate(item);
        }
    }
}
