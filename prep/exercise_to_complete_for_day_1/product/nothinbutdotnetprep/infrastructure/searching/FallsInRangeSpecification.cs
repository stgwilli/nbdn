using System;
using nothinbutdotnetprep.infrastructure.ranges;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class FallsInRangeSpecification<T> : Specification<T> where T : IComparable<T>
    {
        Range<T> range;

        public FallsInRangeSpecification(Range<T> range)
        {
            this.range = range;
        }

        public bool is_satisfied_by(T item)
        {
            return range.contains(item);
        }
    }
}