using System;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class SpecificationFactory<ItemToFilter, ItemProperty> 
    {
        Func<ItemToFilter, ItemProperty> property_accessor;
        
        public SpecificationFactory(Func<ItemToFilter, ItemProperty> property_accessor)
        {
            this.property_accessor = property_accessor;
        }

        public Specification<ItemToFilter> equal_to(ItemProperty value)
        {
            return new EqualSpecification<ItemToFilter, ItemProperty>()
        }
    }
}
