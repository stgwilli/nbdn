using System.Collections.Generic;
using nothinbutdotnetprep.infrastructure.extensions;

namespace nothinbutdotnetprep.infrastructure.searching
{
    static public class SpecificationExtensions
    {
        static public Specification<T> or<T>(this Specification<T> left_side, Specification<T> right_side)
        {
            return new OrSpecification<T>(left_side, right_side);
        }

        static public Specification<T> and<T>(this Specification<T> left_side, Specification<T> right_side)
        {
            return new AndSpecification<T>(left_side, right_side);
        }

        static public IEnumerable<T> that_match<T>(this IEnumerable<T> items, Specification<T> specification)
        {
            return items.that_match(specification.is_satisfied_by);
        }
    }
}