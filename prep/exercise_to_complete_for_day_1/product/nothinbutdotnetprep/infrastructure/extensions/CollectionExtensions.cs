using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.extensions
{
    public static class CollectionExtensions
    {
        public static void add_all<T>(this IList<T> list, params T[] items)
        {
            foreach (var t in items) list.Add(t);
        }

        public static IEnumerable<T> where<T>(this IEnumerable<T> list, Predicate<T> where_clause)
        {
            foreach (var item in list)
                if (where_clause(item))
                    yield return item;
        }
    }
}