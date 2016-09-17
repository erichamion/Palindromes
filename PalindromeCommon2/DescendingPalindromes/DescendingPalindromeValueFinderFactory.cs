using PalindromeCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindromes.DescendingPalindromes
{
    public class DescendingPalindromeValueFinderFactory : IValueFinderFactory
    {
        public ValueFinderCreator CreateValueFinder { get; } =
            factorDigits => new FirstValidValueFinder(new DescendingPalindromeSupplier(factorDigits * 2), new MultipleOfNDigitsChecker(factorDigits));
    }
}
