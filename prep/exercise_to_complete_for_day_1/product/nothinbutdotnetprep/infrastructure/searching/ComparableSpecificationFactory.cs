using System;
using nothinbutdotnetprep.collections;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class ComparableSpecificationFactory<ItemToFilter, ItemProperty> where ItemProperty : IComparable<ItemProperty>
    {
        Func<ItemToFilter, ItemProperty> property_accessor;

        public ComparableSpecificationFactory(Func<ItemToFilter, ItemProperty> property_accessor)
        {
            this.property_accessor = property_accessor;
        }

        public Specification<ItemToFilter> greater_than(ItemProperty value)
        {
            return new AnonymousSpecification<ItemToFilter>(f => property_accessor(f).CompareTo(value) > 0);
        }

        public Specification<ItemToFilter> between(ItemProperty lowerValue, ItemProperty upperValue)
        {
            return new AnonymousSpecification<ItemToFilter>(f => property_accessor(f).CompareTo(lowerValue) >= 0 && property_accessor(f).CompareTo(upperValue) <= 0);
        }
    }
}