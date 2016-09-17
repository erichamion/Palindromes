using Palindromes.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindromes.DescendingPalindromes
{
    public abstract class AbstractDigitListSupplier : AbstractValueSupplier<IEnumerable<int>>
    {
        protected virtual IEnumerable<int> Digits { get; }

        public abstract void Reset();
        public abstract void Reset(int numDigits);
    }
}
