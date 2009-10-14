using System;
using nothinbutdotnetprep.infrastructure.ranges;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public interface ComparableSpecificationFactory<ItemToFilter, ItemProperty> : SpecificationFactory<ItemToFilter, ItemProperty> where ItemProperty : IComparable<ItemProperty>
    {
        Specification<ItemToFilter> greater_than(ItemProperty value);
        Specification<ItemToFilter> between(ItemProperty lowerValue, ItemProperty upperValue);
        Specification<ItemToFilter> falls_in(Range<ItemProperty> range);
    }

    
}
