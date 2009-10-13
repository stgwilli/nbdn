using System;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class DefaultSpecificationFactory<ItemToFilter, ItemProperty> : SpecificationFactory<ItemToFilter,ItemProperty>
    {
        Func<ItemToFilter, ItemProperty> property_accessor;

        public NotSpecificationFactory<ItemToFilter, ItemProperty> not
        {
            get
            {
                return new NotSpecificationFactory<ItemToFilter, ItemProperty>(this);
            }
        }

        public DefaultSpecificationFactory(Func<ItemToFilter, ItemProperty> property_accessor)
        {
            this.property_accessor = property_accessor;
        }

        public Specification<ItemToFilter> equal_to(ItemProperty value)
        {
            return new PropertySpecification<ItemToFilter, ItemProperty>(property_accessor,
                                                                         new EqualsSpecification<ItemProperty>(value));
        }

        public Specification<ItemToFilter> equal_to_any(params ItemProperty[] list)
        {
            return new AnonymousSpecification<ItemToFilter>(f =>
            {
                var have_match = false;
                foreach (var value in list)
                {
                    have_match = have_match ||
                                 property_accessor(f).Equals(value);
                }
                return have_match;
            });
        }
    }
}