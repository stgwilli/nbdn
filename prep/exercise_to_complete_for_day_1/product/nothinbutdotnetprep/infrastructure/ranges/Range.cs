using System;

namespace nothinbutdotnetprep.infrastructure.ranges
{
    public interface Range<T> where T : IComparable<T>
    {
        bool contains(T item);
    }
}