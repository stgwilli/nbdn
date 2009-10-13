using System;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class Where<ItemToFilter>
    {
        public static SpecificationFactory<ItemToFilter, ItemProperty> has_a<ItemProperty>(Func<ItemToFilter, ItemProperty> property_accessor)
        {
            return new SpecificationFactory<ItemToFilter, ItemProperty>(property_accessor);
        }

        public static YouFigureItOut<ItemToFilter, ItemProperty> has_an<ItemProperty>(Func<ItemToFilter, ItemProperty> property_accessor) where ItemProperty : IComparable<ItemProperty>
        {
            return new SpecificationFactory<ItemToFilter, ItemProperty>(property_accessor);
        }
    }
}