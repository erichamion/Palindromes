//using PalindromeCommon;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace SimplePalindromes
//{
//    public class SimpleHighestPalindromicMultipleFinder : IValueFinder
//    {
//        private AbstractValueSupplier<long> _multiples;
//        private IValueChecker<long> _palindromeChecker;

//        public SimpleHighestPalindromicMultipleFinder(int numDigits) : this((int)Math.Pow(10, numDigits - 1), (int)Math.Pow(10, numDigits) - 1)
//        { }

//        public SimpleHighestPalindromicMultipleFinder(int min, int max)
//            : this(min, max, new PalindromeChecker())
//        { }

//        public SimpleHighestPalindromicMultipleFinder(AbstractValueSupplier<long> multipleSupplier)
//            : this(multipleSupplier, new PalindromeChecker())
//        { }

//        public SimpleHighestPalindromicMultipleFinder(int min, int max, IValueChecker<long> palindromeChecker)
//            : this(new UnorderedMultipleSupplier(min, max), palindromeChecker)
//        { }

//        public SimpleHighestPalindromicMultipleFinder(AbstractValueSupplier<long> multipleSupplier, IValueChecker<long> palindromeChecker)
//        {
//            _multiples = multipleSupplier;
//            _palindromeChecker = palindromeChecker;
//        }

//        public long FindValue()
//        {
//            long bestPalindrome = 0;
//            foreach (long multiple in _multiples)
//            {
//                if (multiple > bestPalindrome && _palindromeChecker.IsValueValid(multiple))
//                {
//                    bestPalindrome = multiple;
//                }
//            }
//            return bestPalindrome;
//        }
//    }
//}
