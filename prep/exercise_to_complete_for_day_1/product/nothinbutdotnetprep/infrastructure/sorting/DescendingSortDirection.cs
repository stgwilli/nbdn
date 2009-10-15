using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.sorting
{
    public class DescendingSortDirection : SortDirection
    {
        public IComparer<T> apply_against<T>(IComparer<T> comparer)
        {
            return new ReverseComparer<T>(comparer);
        }
    }
}