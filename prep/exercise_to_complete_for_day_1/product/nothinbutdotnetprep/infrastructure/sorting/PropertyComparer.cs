using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.sorting
{
    public class PropertyComparer<Item, Property> : IComparer<Item> where Property : IComparable<Property>
    {
        Func<Item, Property> property_accessor;

        public PropertyComparer(Func<Item, Property> property_accessor)
        {
            this.property_accessor = property_accessor;
        }


        public int Compare(Item x, Item y)
        {
            return property_accessor(x).CompareTo(property_accessor(y));
        }
    }
}