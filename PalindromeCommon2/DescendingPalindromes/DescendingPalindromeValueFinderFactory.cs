using Palindromes.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindromes.DescendingPalindromes
{
    public class DescendingPalindromeValueFinderFactory : IValueFinderStrategy
    {
        //public ValueFinderCreator CreateValueFinder { get; } =
        //    factorDigits => new FirstValidValueFinder(new DescendingPalindromeSupplier(factorDigits * 2), new MultipleOfNDigitsChecker(factorDigits));

        public string Description { get; } =
            "Generate palindromes in descending order, and test for factorability until the first multiple of two N-digit numbers is found.";

        IValueFinder IValueFinderStrategy.CreateValueFinder(int numDigits)
        {
            return new FirstValidValueFinder(new DescendingPalindromeSupplier(numDigits * 2), new MultipleOfNDigitsChecker(numDigits));
        }
    }
}
