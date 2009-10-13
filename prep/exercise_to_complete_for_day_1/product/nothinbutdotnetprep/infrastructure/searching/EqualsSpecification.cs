namespace nothinbutdotnetprep.infrastructure.searching
{
    public class EqualsSpecification<T> : Specification<T>
    {
        T value;

        public EqualsSpecification(T value)
        {
            this.value = value;
        }

        public bool is_satisfied_by(T unknown)
        {
            return value.Equals(unknown);
        }
    }
}