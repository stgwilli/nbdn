namespace nothinbutdotnetprep.infrastructure.searching
{
    public class NotSpecification<T> : Specification<T>
    {
        Specification<T> _to_negate;

        public NotSpecification(Specification<T> to_negate)
        {
            _to_negate = to_negate;
        }

        public bool is_satisfied_by(T item)
        {
            return !_to_negate.is_satisfied_by(item);
        }
    }
}
