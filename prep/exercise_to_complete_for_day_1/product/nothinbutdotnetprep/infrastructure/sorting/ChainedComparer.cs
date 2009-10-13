using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.sorting
{
    public class ChainedComparer<T> : IComparer<T>
    {
        private readonly IComparer<T> _first;
        private readonly IComparer<T> _second;

        public ChainedComparer(IComparer<T> first, IComparer<T> second)
        {
            _first = first;
            _second = second;
        }

        public int Compare(T x, T y)
        {
            var result = _first.Compare(x, y);

            if (result == 0) return _second.Compare(x, y);

            return result;
        }
    }
}