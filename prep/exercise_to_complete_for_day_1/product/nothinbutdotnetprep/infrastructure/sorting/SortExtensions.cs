using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nothinbutdotnetprep.infrastructure.sorting
{
    public static class SortExtensions
    {
        public static IComparer<T> reverse<T>(this IComparer<T> comparer)
        {
            return new ReverseComparer<T>(comparer);
        }

        public static IComparer<T> followed_by<T>(this IComparer<T> first_comparer, IComparer<T> second_comparer)
        {
            return new ChainedComparer<T>(first_comparer, second_comparer);
        }
    }
}
