using System;
using System.Collections.Generic;
using nothinbutdotnetprep.infrastructure.extensions;

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
            return new AnonymousSpecification<ItemToFilter>(f => property_accessor(f).Equals(value));
        }
        public Specification<ItemToFilter> equal_to_any(params ItemProperty[] list)
        {
            return new AnonymousSpecification<ItemToFilter>(f =>
                                                                {
                                                                    bool have_match = false;
                                                                    foreach (ItemProperty value in list)
                                                                    {
                                                                        have_match = have_match ||
                                                                                     property_accessor(f).Equals(value);
                                                                    }
                                                                    return have_match;
                                                                });
        }
    }
}
