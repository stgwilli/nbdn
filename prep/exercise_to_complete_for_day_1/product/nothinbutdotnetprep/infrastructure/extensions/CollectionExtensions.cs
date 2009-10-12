using System;
using System.Collections;
using System.Collections.Generic;
using nothinbutdotnetprep.collections;

namespace nothinbutdotnetprep.infrastructure.extensions
{
    public static class CollectionExtensions
    {
        public static void add_all<T>(this IList<T> list, params T[] items)
        {
            foreach (var t in items) list.Add(t);
        }

        public static IEnumerable<T> Search<T>(this IList<T> list, Predicate<T> predicate)
        {
            foreach (var item in list)
            {
                if (predicate(item))
                    yield return item;
            }
        }

    }
}