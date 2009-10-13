namespace nothinbutdotnetprep.infrastructure.searching
{
    public interface NegatingSpecificationFactory<ItemToFilter, ItemProperty> : SpecificationFactory<ItemToFilter, ItemProperty>
    {
        SpecificationFactory<ItemToFilter, ItemProperty> not { get; }
    }
}