namespace nothinbutdotnetprep.infrastructure.searching
{
    public interface SpecificationFactory<ItemToFilter, ItemProperty> {
        Specification<ItemToFilter> equal_to(ItemProperty value);
        Specification<ItemToFilter> equal_to_any(params ItemProperty[] list);
    }
}