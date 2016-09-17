using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindromes.DescendingPalindromes
{
    /// <summary>
    /// Supplies consecutive descending numbers in the form of an array of digits, with the least significant
    /// digit at index 0. Only returns numbers that have the same number of digits as initially specified,
    /// never with a high-order digit of 0 (e.g., if numDigits is 3, the last value returned will be 100, 
    /// { 0, 0, 1 }.
    /// </summary>
    public sealed class DescendingDigitListSupplier : AbstractDigitListSupplier
    {
        private int[] _digits;

        protected override IEnumerable<int> Digits
        {
            get
            {
                return _digits;
            }
        }

        public DescendingDigitListSupplier(int numDigits) {
            Reset(numDigits);
        }

        public override IEnumerable<int> NextValue
        {
            get
            {
                // Need to return a copy so that we can prepare for the next call without
                // stomping on the returned list.
                List<int> result = new List<int>(Digits);
                Decrement();
                return result;
            }
        }

        public override bool HasNext()
        {
            return _digits[_digits.Length - 1] != 0;
        }

        public override void Reset()
        {
            for (int i = 0; i < _digits.Length; i++)
            {
                _digits[i] = 9;
            }
        }

        public override void Reset(int numDigits)
        {
            _digits = Enumerable.Repeat(9, numDigits).ToArray();
        }

        private void Decrement()
        {
            int currentDigit = 0;
            _digits[currentDigit]--;
            while (_digits[currentDigit] < 0)
            {
                _digits[currentDigit] = 9;
                _digits[++currentDigit]--;
            }
        }
    }
}
