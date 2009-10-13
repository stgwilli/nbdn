using System;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class PropertySpecification<ItemToFilter,PropertyType> : Specification<ItemToFilter>
    {
        Func<ItemToFilter, PropertyType> accessor;
        Specification<PropertyType> criteria;

        public PropertySpecification(Func<ItemToFilter, PropertyType> accessor, Specification<PropertyType> criteria)
        {
            this.accessor = accessor;
            this.criteria = criteria;
        }

        public bool is_satisfied_by(ItemToFilter item)
        {
            return criteria.is_satisfied_by(accessor(item));
        }
    }
}