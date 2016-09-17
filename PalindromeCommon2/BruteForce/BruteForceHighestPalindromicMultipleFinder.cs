using PalindromeCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindromes.BruteForce
{
    public class BruteForceHighestPalindromicMultipleFinder : IValueFinder
    {
        private AbstractValueSupplier<long> _multiples;
        private IValueChecker<long> _palindromeChecker;

        public BruteForceHighestPalindromicMultipleFinder(int numDigits) : this((int)Math.Pow(10, numDigits - 1), (int)Math.Pow(10, numDigits) - 1)
        { }

        public BruteForceHighestPalindromicMultipleFinder(int min, int max)
            : this(min, max, new PalindromeChecker())
        { }

        public BruteForceHighestPalindromicMultipleFinder(AbstractValueSupplier<long> multipleSupplier)
            : this(multipleSupplier, new PalindromeChecker())
        { }

        public BruteForceHighestPalindromicMultipleFinder(int min, int max, IValueChecker<long> palindromeChecker)
            : this(new UnorderedMultipleSupplier(min, max), palindromeChecker)
        { }

        public BruteForceHighestPalindromicMultipleFinder(AbstractValueSupplier<long> multipleSupplier, IValueChecker<long> palindromeChecker)
        {
            _multiples = multipleSupplier;
            _palindromeChecker = palindromeChecker;
        }

        public long FindValue()
        {
            long bestPalindrome = 0;
            foreach (long multiple in _multiples)
            {
                if (multiple > bestPalindrome && _palindromeChecker.IsValueValid(multiple))
                {
                    bestPalindrome = multiple;
                }
            }
            return bestPalindrome;
        }
    }
}
