using PalindromeCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalindromesByDescendingPalindromeGeneration
{
    public class MultipleOfNDigitsChecker : IValueChecker<long>
    {
        private readonly int _minFactor;
        private readonly int _maxFactor;
        public MultipleOfNDigitsChecker(int numDigits)
        {
            _minFactor = (int)Math.Pow(10, numDigits - 1);
            _maxFactor = (int)Math.Pow(10, numDigits) - 1;
        }

        public bool IsValueValid(long value)
        {
            int effectiveMin = Math.Max(_minFactor, (int)Math.Sqrt(value));
            int effectiveMax = (int)Math.Min(_maxFactor, value);
            for (int i = effectiveMin; i <= effectiveMax; i++)
            {
                long quotient = value / i;
                long remainder = value % i;
                if (remainder == 0 && quotient >= _minFactor && quotient <= _maxFactor)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
