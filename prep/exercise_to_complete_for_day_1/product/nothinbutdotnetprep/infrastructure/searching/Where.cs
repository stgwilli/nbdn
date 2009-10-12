using System;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class Where<ItemToFilter>
    {
        public static Where<ItemToFilter, ItemProperty> has_a<ItemProperty>(Func<ItemToFilter, ItemProperty> get_property_value)
        {
            return new Where<ItemToFilter, ItemProperty>(get_property_value);
        }
    }

    public class Where<ItemToFilter, ItemProperty> : Where<ItemToFilter>
    {
        readonly Func<ItemToFilter, ItemProperty> get_property_value;
        
        public Where(Func<ItemToFilter, ItemProperty> get_property_value)
        {
            this.get_property_value = get_property_value;
        }

        public Specification<ItemToFilter> equal_to(ItemProperty property)
        {
            return new EqualSpecification<ItemToFilter, ItemProperty>(get_property_value, property);
        }
    }
}
