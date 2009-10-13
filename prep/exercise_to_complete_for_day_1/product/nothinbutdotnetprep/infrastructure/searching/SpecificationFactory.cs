using System;
using nothinbutdotnetprep.infrastructure.ranges;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public interface SpecificationFactory<ItemToFilter, ItemProperty> {
        Specification<ItemToFilter> equal_to(ItemProperty value);
        Specification<ItemToFilter> equal_to_any(params ItemProperty[] list);
    }

    public interface NegatingFactory<ItemToFilter, ItemProperty>
    {
        SpecificationFactory<ItemToFilter, ItemProperty> not { get; }
    }

    public interface BasicSpecificationFactory<ItemToFilter, ItemProperty> : SpecificationFactory<ItemToFilter, ItemProperty>, NegatingFactory<ItemToFilter, ItemProperty>
    {

    }

    public interface BasicComparableSpecificationFactory<ItemToFilter, ItemProperty> : BasicSpecificationFactory<ItemToFilter, ItemProperty> where ItemProperty : IComparable<ItemProperty>
    {
        Specification<ItemToFilter> greater_than(ItemProperty value);
        Specification<ItemToFilter> between(ItemProperty lowerValue, ItemProperty upperValue);
        Specification<ItemToFilter> falls_in(Range<ItemProperty> range);
    }
}