using System;
using System.Collections.Generic;
using nothinbutdotnetprep.infrastructure.searching;

namespace nothinbutdotnetprep.infrastructure.extensions
{
    static public class CollectionExtensions
    {
        static public void add_all<T>(this IList<T> list, params T[] items)
        {
            foreach (var t in items) list.Add(t);
        }

        static public IEnumerable<T> all_matching<T>(this IEnumerable<T> list, Specification<T> condition)
        {
            foreach (var item in list) if (condition.is_satisfied_by(item)) yield return item;
        }

        static public IEnumerable<T> sort<T>(this IEnumerable<T> items, IComparer<T> comparer)
        {
            var list = new List<T>(items);
            list.Sort(comparer);
            return list.one_at_a_time();
        }
    }
}