using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalindromesByDescendingPalindromeGeneration
{

    public class NumberMirrorer : INumberMirrorer
    {
        /// <summary>
        /// Creates a palindromic number by mirroring a given set of digits.
        /// </summary>
        /// <param name="digits">Must be ordered with least-significant digit first, most-significant digit last.</param>
        /// <param name="resultHasOddDigits"></param>
        /// <returns></returns>
        public long Mirror(IEnumerable<int> digits, bool resultHasOddDigits)
        {
            long rightMultiple = (long)Math.Pow(10, digits.Count() - 1);
            long leftMultiple = rightMultiple * (resultHasOddDigits ? 1 : 10);

            long result = 0;
            foreach (int digit in digits)
            {
                long effectiveMultiple = (leftMultiple == rightMultiple) ? 
                    leftMultiple : 
                    leftMultiple + rightMultiple;
                result += digit * effectiveMultiple;

                leftMultiple *= 10;
                rightMultiple /= 10;
            }

            return result;
        }
    }
}
