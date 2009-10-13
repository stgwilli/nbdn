using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.sorting
{
    public class ReverseComparer<T> : IComparer<T>
    {
        IComparer<T> comparer;

        public ReverseComparer(IComparer<T> comparer)
        {
            this.comparer = comparer;
        }

        public int Compare(T x, T y)
        {
            return -comparer.Compare(x, y);
        }
    }
}