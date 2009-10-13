namespace nothinbutdotnetprep.infrastructure.searching
{
    public class NotSpecification<T> : Specification<T>
    {
        Specification<T> original;

        public NotSpecification(Specification<T> original)
        {
            this.original = original;
        }

        public bool is_satisfied_by(T item)
        {
            return !original.is_satisfied_by(item);
        }
    }
}
