using System;
using nothinbutdotnetprep.infrastructure.ranges;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class NotComparableSpecificationFactory<ItemToFilter, ItemProperty> where ItemProperty : IComparable<ItemProperty>
    {
        private readonly ComparableSpecificationFactory<ItemToFilter, ItemProperty> _basicFactory;

        public NotComparableSpecificationFactory(ComparableSpecificationFactory<ItemToFilter, ItemProperty> basic_factory)
        {
            _basicFactory = basic_factory;
        }

        public Specification<ItemToFilter> equal_to(ItemProperty value)
        {
            return new NotSpecification<ItemToFilter>(_basicFactory.equal_to(value));
        }

        public Specification<ItemToFilter> equal_to_any(params ItemProperty[] list)
        {
            return new NotSpecification<ItemToFilter>(_basicFactory.equal_to_any(list));
        }

        public Specification<ItemToFilter> greater_than(ItemProperty value)
        {
            return new NotSpecification<ItemToFilter>(_basicFactory.greater_than(value));
        }
        
        public Specification<ItemToFilter> between(ItemProperty lowerValue, ItemProperty upperValue)
        {
            return new NotSpecification<ItemToFilter>(_basicFactory.between(lowerValue, upperValue));
        }

        public Specification<ItemToFilter> falls_in(Range<ItemProperty> range)
        {
            return new NotSpecification<ItemToFilter>(_basicFactory.falls_in(range));
        }

        public SpecificationFactory<ItemToFilter, ItemProperty> not
        {
            get { return _basicFactory; }
        }
    }
}