using System;
using System.Collections;
using System.Collections.Generic;

namespace Palindromes.Common
{
    public abstract class AbstractValueSupplier<T> : IEnumerable<T>
    {
        public abstract T NextValue { get; }
        public abstract bool HasNext();

        public virtual IEnumerator<T> GetEnumerator()
        {
            return new ValueEnumerator<T>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}