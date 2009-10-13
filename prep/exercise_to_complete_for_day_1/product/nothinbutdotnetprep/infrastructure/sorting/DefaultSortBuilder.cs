using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.sorting
{
    public interface SortBuilder<ItemToSort> : IComparer<ItemToSort>
    {
        DefaultSortBuilder<ItemToSort> then_by<ItemProperty>(Func<ItemToSort, ItemProperty> property_accessor) where ItemProperty : IComparable<ItemProperty>;
        DefaultSortBuilder<ItemToSort> then_by_desc<ItemProperty>(Func<ItemToSort, ItemProperty> property_accessor) where ItemProperty : IComparable<ItemProperty>;
        DefaultSortBuilder<ItemToSort> then_by(IComparer<ItemToSort> custom_comparer);
    }

    public class DefaultSortBuilder<ItemToSort> : SortBuilder<ItemToSort>
    {
        IComparer<ItemToSort> comparer;

        public DefaultSortBuilder(IComparer<ItemToSort> comparer)
        {
            this.comparer = comparer;
        }

        public DefaultSortBuilder<ItemToSort> then_by<ItemProperty>(Func<ItemToSort, ItemProperty> property_accessor) where ItemProperty : IComparable<ItemProperty>
        {
            return then_by(next_comparer(property_accessor));
        }


        public DefaultSortBuilder<ItemToSort> then_by_desc<ItemProperty>(Func<ItemToSort, ItemProperty> property_accessor) where ItemProperty : IComparable<ItemProperty>
        {
            return then_by(next_comparer(property_accessor).reverse());
        }

        public DefaultSortBuilder<ItemToSort> then_by(IComparer<ItemToSort> custom_comparer)
        {
            comparer = comparer.followed_by(custom_comparer);
            return this;
        }

        public int Compare(ItemToSort x, ItemToSort y)
        {
            return comparer.Compare(x, y);
        }

        public IComparer<ItemToSort> build()
        {
            return comparer;
        }

        PropertyComparer<ItemToSort, ItemProperty> next_comparer<ItemProperty>(Func<ItemToSort, ItemProperty> property_accessor) where ItemProperty : IComparable<ItemProperty>
        {
            return new PropertyComparer<ItemToSort, ItemProperty>(property_accessor);
        }
    }
}