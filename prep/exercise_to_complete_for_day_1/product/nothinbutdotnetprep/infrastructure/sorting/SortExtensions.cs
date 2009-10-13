using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nothinbutdotnetprep.infrastructure.extensions;

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

        public static IEnumerable<ItemToSort> order_by<ItemToSort, ItemProperty>(this IEnumerable<ItemToSort> items, Func<ItemToSort, ItemProperty> property_accessor) where ItemProperty: IComparable<ItemProperty>
        {
            return items.sort(new PropertyComparer<ItemToSort, ItemProperty>(property_accessor));
        }

        public static IEnumerable<ItemToSort> then_by<ItemToSort, ItemProperty>(this IEnumerable<ItemToSort> items, Func<ItemToSort, ItemProperty> property_accessor) where ItemProperty : IComparable<ItemProperty>
        {
            return order_by(items, property_accessor);
        }
    }
}
