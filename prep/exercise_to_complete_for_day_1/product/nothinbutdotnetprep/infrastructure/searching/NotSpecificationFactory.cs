namespace nothinbutdotnetprep.infrastructure.searching
{
    public class NotSpecificationFactory<ItemToFilter, ItemProperty> 
    {
        private SpecificationFactory<ItemToFilter, ItemProperty> specification_factory;


        public NotSpecificationFactory(SpecificationFactory<ItemToFilter, ItemProperty> specificationFactory)
        {
            specification_factory = specificationFactory;
        }

        public Specification<ItemToFilter> equal_to(ItemProperty value)
        {
            return new NotSpecification<ItemToFilter>(specification_factory.equal_to(value));
        }

        public Specification<ItemToFilter> equal_to_any(params ItemProperty[] list)
        {
            return new NotSpecification<ItemToFilter>(specification_factory.equal_to_any(list));
        }
    }
}
