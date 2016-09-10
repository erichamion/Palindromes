using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalindromeCommon
{
    sealed class ValueEnumerator<T> : IEnumerator<T>
    {
        private readonly AbstractValueSupplier<T> _valueSupplier;

        public ValueEnumerator(AbstractValueSupplier<T> valueSupplier)
        {
            _valueSupplier = valueSupplier;
        }
        public T Current
        {
            get;
            private set;
        }

        object IEnumerator.Current
        {
            get
            {
                return this.Current;
            }
        }

        public void Dispose()
        { }

        public bool MoveNext()
        {
            if (_valueSupplier.HasNext())
            {
                Current = _valueSupplier.NextValue;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
