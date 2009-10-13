using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.sorting
{
    public class Sort<ItemToSort>
    {
        public static SortBuilder<ItemToSort> by<ItemProperty>(Func<ItemToSort, ItemProperty> property_accessor) where ItemProperty : IComparable<ItemProperty>
        {
            return with(new PropertyComparer<ItemToSort, ItemProperty>(property_accessor));
        }

        public static SortBuilder<ItemToSort> by_descending<ItemProperty>(Func<ItemToSort, ItemProperty> property_accessor) where ItemProperty: IComparable<ItemProperty>
        {
            return with(new PropertyComparer<ItemToSort, ItemProperty>(property_accessor).reverse());
        }

        public static SortBuilder<ItemToSort>with(IComparer<ItemToSort> custom_comparer)
        {
            return new SortBuilder<ItemToSort>(custom_comparer);
        }
    }
}