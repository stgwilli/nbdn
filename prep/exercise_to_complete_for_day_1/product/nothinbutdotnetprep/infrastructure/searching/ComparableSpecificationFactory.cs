using System;
using nothinbutdotnetprep.infrastructure.ranges;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class ComparableSpecificationFactory<ItemToFilter, ItemProperty> : BasicComparableSpecificationFactory<ItemToFilter, ItemProperty> where ItemProperty : IComparable<ItemProperty>
    {
        Func<ItemToFilter, ItemProperty> property_accessor;
        SpecificationFactory<ItemToFilter, ItemProperty> basic_factory;

        public ComparableSpecificationFactory(Func<ItemToFilter, ItemProperty> property_accessor, SpecificationFactory<ItemToFilter, ItemProperty> basic_factory)
        {
            this.property_accessor = property_accessor;
            this.basic_factory = basic_factory;
        }

        public ComparableSpecificationFactory(Func<ItemToFilter, ItemProperty> property_accessor) : this(property_accessor, new DefaultSpecificationFactory<ItemToFilter, ItemProperty>(property_accessor)) {}

        public Specification<ItemToFilter> equal_to(ItemProperty value)
        {
            return basic_factory.equal_to(value);
        }

        public Specification<ItemToFilter> equal_to_any(params ItemProperty[] list)
        {
            return basic_factory.equal_to_any(list);
        }

        public Specification<ItemToFilter> greater_than(ItemProperty value)
        {
            return new PropertySpecification<ItemToFilter, ItemProperty>(property_accessor,
                                                                         new GreaterThanSpecification<ItemProperty>(value));
        }

        public Specification<ItemToFilter> between(ItemProperty lowerValue, ItemProperty upperValue)
        {
            return new AnonymousSpecification<ItemToFilter>(f => property_accessor(f).CompareTo(lowerValue) >= 0 && property_accessor(f).CompareTo(upperValue) <= 0);
        }

        public Specification<ItemToFilter> falls_in(Range<ItemProperty> range)
        {
            return new PropertySpecification<ItemToFilter, ItemProperty>(property_accessor,
                new FallsInRangeSpecification<ItemProperty>(range));
        }

        public SpecificationFactory<ItemToFilter, ItemProperty> not
        {
            get { throw new NotImplementedException(); }
        }
    }
}