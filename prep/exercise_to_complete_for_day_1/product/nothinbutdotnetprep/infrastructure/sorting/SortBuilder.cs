using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.sorting
{
    

    public class SortBuilder<ItemToSort>
    {
        private IComparer<ItemToSort> _comparer;

        public SortBuilder(IComparer<ItemToSort> comparer)
        {
            _comparer = comparer;
        }

        public SortBuilder<ItemToSort> then_by<ItemProperty>(Func<ItemToSort, ItemProperty> property_accessor)
        {
            _comparer = _comparer.chain_with(next_comparer(property_accessor));
            return this;
        }

        public SortBuilder<ItemToSort> then_by(IComparer<ItemToSort> custom_comparer)
        {
            _comparer = _comparer.chain_with(custom_comparer);
            return this;
        }


        public SortBuilder<ItemToSort> then_by_desc<ItemProperty>(Func<ItemToSort, ItemProperty> property_accessor)
        {
            _comparer = _comparer.chain_with(next_comparer(property_accessor).reverse());

            return this;
        }

        public SortBuilder<ItemToSort> then_by_desc(IComparer<ItemToSort> custom_comparer)
        {
            _comparer = _comparer.chain_with(custom_comparer.reverse());
            return this;
        }


        public IComparer<ItemToSort> build()
        {
            return _comparer;
        }

        private PropertyComparer<ItemToSort, ItemProperty> next_comparer<ItemProperty>(Func<ItemToSort, ItemProperty> property_accessor)
        {
            return new PropertyComparer<ItemToSort, ItemProperty>(property_accessor);
        }
    }
}