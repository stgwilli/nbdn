using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.sorting
{
    public class PropertyComparer<Item, Property> : IComparer<Item>
    {
        private readonly Comparison<Property> _comparison;
        private readonly Func<Item, Property> _propertyAccessor;

        public PropertyComparer(Func<Item, Property> property_accessor)
            : this(Comparer<Property>.Default.Compare, property_accessor)
        {
        }

        public PropertyComparer(Comparison<Property> comparer, Func<Item, Property> property_accessor)
        {
            _comparison = comparer;
            _propertyAccessor = property_accessor;
        }

        public int Compare(Item x, Item y)
        {
            
            return _comparison(_propertyAccessor(x), _propertyAccessor(y));
        }
    }
}