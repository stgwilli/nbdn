using System;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class NotSpecificationFactory<ItemToFilter, ItemProperty> : NegatingSpecificationFactory<ItemToFilter, ItemProperty>
    {
        private readonly SpecificationFactory<ItemToFilter, ItemProperty> _specificationFactory;


        public NotSpecificationFactory(SpecificationFactory<ItemToFilter, ItemProperty> specificationFactory)
        {
            _specificationFactory = specificationFactory;
        }

        public SpecificationFactory<ItemToFilter, ItemProperty> not
        {
            get { return _specificationFactory; }
        }

        public Specification<ItemToFilter> equal_to(ItemProperty value)
        {
            return new NotSpecification<ItemToFilter>(_specificationFactory.equal_to(value));
        }

        public Specification<ItemToFilter> equal_to_any(params ItemProperty[] list)
        {
            return new NotSpecification<ItemToFilter>(_specificationFactory.equal_to_any(list));
        }
    }
}