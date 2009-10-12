using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.extensions
{
    public static class CollectionExtensions
    {
        public static void add_all<T>(this IList<T> list, params T[] items)
        {
            foreach (var t in items) list.Add(t);
        }
    }
}