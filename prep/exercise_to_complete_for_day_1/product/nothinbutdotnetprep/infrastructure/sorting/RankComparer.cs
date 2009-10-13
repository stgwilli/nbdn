using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.sorting
{
    public class RankComparer<ItemToSort, ItemProperty> : IComparer<ItemToSort>
    {
        private readonly Func<ItemToSort, ItemProperty> propertyAccessor;
        private Dictionary<ItemProperty, int> ranking = new Dictionary<ItemProperty, int>();

        public RankComparer(Func<ItemToSort, ItemProperty> property_accessor, params ItemProperty[] rankings)
        {
            propertyAccessor = property_accessor;
            int i = 0;
            foreach(var item in rankings)
            {
                ranking.Add(item, i++);
            }
        }

        public int Compare(ItemToSort x, ItemToSort y)
        {
            return ranking[propertyAccessor(x)].CompareTo(ranking[propertyAccessor(y)]);
        }
    }
}