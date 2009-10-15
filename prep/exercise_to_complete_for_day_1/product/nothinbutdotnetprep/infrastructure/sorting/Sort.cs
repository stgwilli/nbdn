using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.sorting
{
    public class Sort<ItemToSort>
    {
        public static DefaultSortBuilder<ItemToSort> by<ItemProperty>(Func<ItemToSort, ItemProperty> property_accessor) where ItemProperty : IComparable<ItemProperty>
        {
            return with(new PropertyComparer<ItemToSort, ItemProperty>(property_accessor));
        }

        public static DefaultSortBuilder<ItemToSort> by<ItemProperty>(Func<ItemToSort, ItemProperty> property_accessor,SortDirection direction) where ItemProperty : IComparable<ItemProperty>
        {
            return with(new PropertyComparer<ItemToSort, ItemProperty>(property_accessor));
        }

        public static DefaultSortBuilder<ItemToSort>with(IComparer<ItemToSort> custom_comparer)
        {
            return new DefaultSortBuilder<ItemToSort>(custom_comparer);
        }
    }
}