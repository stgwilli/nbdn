using System;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public interface Specification<T>
    {
        bool is_satisfied_by(T item);
    }
}