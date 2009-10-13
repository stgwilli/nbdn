using System.Collections;
using System.Collections.Generic;

namespace nothinbutdotnetprep.collections
{
    public class ReadonlyList<T> : IEnumerable<T>
    {
        IList<T> items;

        public ReadonlyList(IList<T> items)
        {
            this.items = items;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return items.GetEnumerator();
        }
    }
}