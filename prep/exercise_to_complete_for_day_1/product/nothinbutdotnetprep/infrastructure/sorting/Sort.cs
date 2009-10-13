using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.sorting
{
    public class Sort<ItemToSort>
    {
        public static SortBuilder<ItemToSort> by<ItemProperty>(Func<ItemToSort, ItemProperty> property_accessor)
        {
            return new SortBuilder<ItemToSort>(new PropertyComparer<ItemToSort, ItemProperty>(property_accessor));
        }

        public static SortBuilder<ItemToSort>by(IComparer<ItemToSort> custom_comparer)
        {
            return new SortBuilder<ItemToSort>(custom_comparer);
        }

        public static SortBuilder<ItemToSort> by_desc<ItemProperty>(Func<ItemToSort, ItemProperty> property_accessor)
        {
            return new SortBuilder<ItemToSort>(new PropertyComparer<ItemToSort, ItemProperty>(property_accessor).reverse());
        }

        public static SortBuilder<ItemToSort> by_desc(IComparer<ItemToSort> custom_comparer)
        {
            return new SortBuilder<ItemToSort>(custom_comparer.reverse());
        }
    }
}