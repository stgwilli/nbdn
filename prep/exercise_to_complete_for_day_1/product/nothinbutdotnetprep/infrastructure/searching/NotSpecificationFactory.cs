using System;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class NotSpecificationFactory<ItemToFilter, ItemProperty> : SpecificationFactory<ItemToFilter, ItemProperty>
    {
        private readonly SpecificationFactory<ItemToFilter, ItemProperty> basic_factory;

        public NotSpecificationFactory(SpecificationFactory<ItemToFilter, ItemProperty> basic_factory)
        {
            this.basic_factory = basic_factory;
        }
        public Specification<ItemToFilter> equal_to(ItemProperty value)
        {
            return new NotSpecification<ItemToFilter>(basic_factory.equal_to(value));
        }

        public Specification<ItemToFilter> equal_to_any(params ItemProperty[] list)
        {
            return new NotSpecification<ItemToFilter>(basic_factory.equal_to_any(list));
        }

    }
}