using System;
using nothinbutdotnetprep.infrastructure.ranges;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class NotComparableSpecificationFactory<ItemToFilter, ItemProperty> : ComparableSpecificationFactory<ItemToFilter,ItemProperty> where ItemProperty : IComparable<ItemProperty>
    {
        ComparableSpecificationFactory<ItemToFilter, ItemProperty> basic_factory;

        public NotComparableSpecificationFactory(ComparableSpecificationFactory<ItemToFilter, ItemProperty> basic_factory)
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

        public Specification<ItemToFilter> greater_than(ItemProperty value)
        {
            return new NotSpecification<ItemToFilter>(basic_factory.greater_than(value));
        }

        public Specification<ItemToFilter> between(ItemProperty lowerValue, ItemProperty upperValue)
        {
            return new NotSpecification<ItemToFilter>(basic_factory.between(lowerValue, upperValue));
        }

        public Specification<ItemToFilter> falls_in(Range<ItemProperty> range)
        {
            return new NotSpecification<ItemToFilter>(basic_factory.falls_in(range));
        }
    }
}