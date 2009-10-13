namespace nothinbutdotnetprep.infrastructure.searching
{
    public class NotSpecification<T>: Specification<T>
    {
        private readonly Specification<T> original_specification;

        public NotSpecification(Specification<T> original_specification)
        {
            this.original_specification = original_specification;
        }

        public bool is_satisfied_by(T item)
        {
            return !original_specification.is_satisfied_by(item);
        }
    }
}