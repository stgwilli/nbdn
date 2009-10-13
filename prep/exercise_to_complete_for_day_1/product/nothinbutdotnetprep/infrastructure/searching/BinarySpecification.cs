namespace nothinbutdotnetprep.infrastructure.searching
{
    public abstract class BinarySpecification<T> : Specification<T>
    {
        protected Specification<T> left_side;
        protected Specification<T> right_side;

        protected BinarySpecification(Specification<T> left_side, Specification<T> right_side)
        {
            this.left_side = left_side;
            this.right_side = right_side;
        }

        public abstract bool is_satisfied_by(T item);
    }
}