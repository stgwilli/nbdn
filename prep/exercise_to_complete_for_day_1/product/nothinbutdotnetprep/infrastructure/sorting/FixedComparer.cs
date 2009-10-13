using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.sorting
{
    public class FixedComparer<ItemToSort, ItemProperty> : IComparer<ItemToSort>
    {
        Func<ItemToSort, ItemProperty> property_accessor;
        IDictionary<ItemProperty, int> ranking = new Dictionary<ItemProperty, int>();

        public FixedComparer(Func<ItemToSort, ItemProperty> property_accessor, params ItemProperty[] rankings)
        {
            this.property_accessor = property_accessor;
            var i = 0;
            foreach(var item in rankings)
            {
                ranking.Add(item, i++);
            }
        }

        public int Compare(ItemToSort x, ItemToSort y)
        {
            return ranking[property_accessor(x)].CompareTo(ranking[property_accessor(y)]);
        }
    }
}