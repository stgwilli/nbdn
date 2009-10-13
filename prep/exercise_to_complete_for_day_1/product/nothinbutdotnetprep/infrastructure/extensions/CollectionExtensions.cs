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

        static public IEnumerable<T> all_matching<T>(this IEnumerable<T> list, Predicate<T> condition)
        {
            foreach (var item in list) if (condition(item)) yield return item;
        }
    }
}