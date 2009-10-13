using System;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public interface NegatingComparableSpecificationFactory<ItemToFilter, ItemProperty> : ComparableSpecificationFactory<ItemToFilter, ItemProperty> where ItemProperty : IComparable<ItemProperty>
    {
        SpecificationFactory<ItemToFilter, ItemProperty> not { get; }    
    }
}