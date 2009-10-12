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
    }
}