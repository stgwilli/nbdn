using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class EqualSpecification<ItemToFilter, PropertyToFilterOn> : Specification<ItemToFilter>
    {
        readonly Func<ItemToFilter, PropertyToFilterOn> get_property_value;
        readonly PropertyToFilterOn property_value;

        public EqualSpecification(Func<ItemToFilter, PropertyToFilterOn> get_property_value, PropertyToFilterOn property_value)
        {
            this.get_property_value = get_property_value;
            this.property_value = property_value;
        }

        public bool is_satisfied_by(ItemToFilter item)
        {
            return get_property_value(item).Equals(property_value);
        }
    }
}
