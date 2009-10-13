using System;
using System.Collections;
using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.sorting
{
    public class ComparableEnumerable<T> : IEnumerable<T>
    {
        SortBuilder<T> builder;
        IEnumerable<T> items;

        public ComparableEnumerable(SortBuilder<T> builder, IEnumerable<T> items)
        {
            this.builder = builder;
            this.items = items;
        }


        public ComparableEnumerable<T> then_by<ItemProperty>(Func<T, ItemProperty> property_accessor) where ItemProperty : IComparable<ItemProperty>
        {
            builder.then_by(property_accessor);
            return this;
            
        }

        public ComparableEnumerable<T> then_by_desc<ItemProperty>(Func<T, ItemProperty> property_accessor) where ItemProperty : IComparable<ItemProperty>
        {
            builder.then_by_desc(property_accessor);
            return this;
        }

        public ComparableEnumerable<T> then_by(IComparer<T> custom_comparer)
        {
            builder.then_by(custom_comparer);
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            var sorted = new List<T>(items);
            sorted.Sort(builder);
            return sorted.GetEnumerator();
        }
    }
}