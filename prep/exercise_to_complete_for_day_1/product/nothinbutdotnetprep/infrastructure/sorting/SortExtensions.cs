using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.sorting
{
    static public class SortExtensions
    {
        static public IComparer<T> reverse<T>(this IComparer<T> comparer)
        {
            return new ReverseComparer<T>(comparer);
        }

        static public IComparer<T> followed_by<T>(this IComparer<T> first_comparer, IComparer<T> second_comparer)
        {
            return new ChainedComparer<T>(first_comparer, second_comparer);
        }

        static public ComparableEnumerable<ItemToSort> order_by<ItemToSort, ItemProperty>(this IEnumerable<ItemToSort> items, Func<ItemToSort, ItemProperty> property_accessor)
            where ItemProperty : IComparable<ItemProperty>
        {
            return order_by(items, property_accessor, SortDirections.ascending);
        }
        static public ComparableEnumerable<ItemToSort> order_by<ItemToSort, ItemProperty>(this IEnumerable<ItemToSort> items, Func<ItemToSort, ItemProperty> property_accessor,SortDirection direction)
            where ItemProperty : IComparable<ItemProperty>
        {
            var property_comparer = new PropertyComparer<ItemToSort,ItemProperty>(property_accessor);
            return new ComparableEnumerable<ItemToSort>(new DefaultSortBuilder<ItemToSort>(direction.apply_against(property_comparer)),items);
        }

        static public ComparableEnumerable<ItemToSort> order_by<ItemToSort, ItemProperty>(this IEnumerable<ItemToSort> items, Func<ItemToSort, ItemProperty> property_accessor, SortDirection direction,
                                                                                          params ItemProperty[] fixed_sort_list)
        {
            IComparer<ItemToSort> fixed_comparer = new FixedComparer<ItemToSort, ItemProperty>(property_accessor, fixed_sort_list);
            fixed_comparer = direction.apply_against(fixed_comparer);

            return
                new ComparableEnumerable<ItemToSort>(new DefaultSortBuilder<ItemToSort>(fixed_comparer), items);
        }
    }
}