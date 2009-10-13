using System;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class Where<ItemToFilter>
    {
        public static DefaultSpecificationFactory<ItemToFilter, ItemProperty> has_a<ItemProperty>(Func<ItemToFilter, ItemProperty> property_accessor)
        {
            return new DefaultSpecificationFactory<ItemToFilter, ItemProperty>(property_accessor);
        }

        public static DefaultComparableSpecificationFactory<ItemToFilter, ItemProperty> has_an<ItemProperty>(Func<ItemToFilter, ItemProperty> property_accessor) where ItemProperty : IComparable<ItemProperty>
        {
            return new DefaultComparableSpecificationFactory<ItemToFilter, ItemProperty>(property_accessor);
        }
    }
}
