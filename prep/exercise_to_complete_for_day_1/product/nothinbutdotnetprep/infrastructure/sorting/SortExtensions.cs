using System;
using System.Collections.Generic;

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

        public static ComparableEnumerable<ItemToSort> order_by<ItemToSort,ItemProperty>(this IEnumerable<ItemToSort> items, Func<ItemToSort, ItemProperty> property_accessor) where ItemProperty: IComparable<ItemProperty>
        {
            return new ComparableEnumerable<ItemToSort>(
                new DefaultSortBuilder<ItemToSort>(new PropertyComparer<ItemToSort, ItemProperty>(property_accessor)), items); 
        }

        public static ComparableEnumerable<ItemToSort> order_by<ItemToSort, ItemProperty>(this IEnumerable<ItemToSort> items, Func<ItemToSort, ItemProperty> property_accessor, params ItemProperty[] fixed_sort_list)
        {
            
            return new ComparableEnumerable<ItemToSort>(new DefaultSortBuilder<ItemToSort>(new FixedComparer<ItemToSort, ItemProperty>(property_accessor, fixed_sort_list)), items);
        }

        public static ComparableEnumerable<ItemToSort> order_by_descending<ItemToSort, ItemProperty>(this IEnumerable<ItemToSort> items, Func<ItemToSort, ItemProperty> property_accessor) where ItemProperty : IComparable<ItemProperty>
        {
            return new ComparableEnumerable<ItemToSort>(
                new DefaultSortBuilder<ItemToSort>(new PropertyComparer<ItemToSort, ItemProperty>(property_accessor).reverse()), items);
        }

        public static ComparableEnumerable<ItemToSort> order_by_descending<ItemToSort, ItemProperty>(this IEnumerable<ItemToSort> items, Func<ItemToSort, ItemProperty> property_accessor, params ItemProperty[] fixedSortList)
        {

            return new ComparableEnumerable<ItemToSort>(new DefaultSortBuilder<ItemToSort>(new FixedComparer<ItemToSort, ItemProperty>(property_accessor, fixedSortList).reverse()), items);
        }

        

    }
}
