using System;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class Where<ItemToFilter>
    {
        public static BasicSpecificationFactory<ItemToFilter, ItemProperty> has_a<ItemProperty>(Func<ItemToFilter, ItemProperty> property_accessor)
        {
            return new DefaultSpecificationFactory<ItemToFilter, ItemProperty>(property_accessor);
        }

        public static BasicComparableSpecificationFactory<ItemToFilter, ItemProperty> has_an<ItemProperty>(Func<ItemToFilter, ItemProperty> property_accessor) where ItemProperty : IComparable<ItemProperty>
        {
            return new ComparableSpecificationFactory<ItemToFilter, ItemProperty>(property_accessor);
        }
    }
}