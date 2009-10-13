using System;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class GreaterThanSpecification<T> : Specification<T> where T : IComparable<T>
    {
        T value;

        public GreaterThanSpecification(T value)
        {
            this.value = value;
        }

        public bool is_satisfied_by(T item)
        {
            return item.CompareTo(value) > 0;
        }
    }
}