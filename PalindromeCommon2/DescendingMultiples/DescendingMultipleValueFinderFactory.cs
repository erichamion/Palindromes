using Palindromes.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindromes.DescendingMultiples
{
    public class DescendingMultipleValueFinderFactory : IValueFinderStrategy
    {
        public ValueFinderFactory CreateValueFinder { get; } =
            x => new FirstValidValueFinder(new DescendingMultipleSupplier(x), new PalindromeChecker());

        public string Description { get; } =
            "Generate multiples in descending order, and test for palindromicity until the first palindrome is found.";

        //IValueFinder IValueFinderStrategy.CreateValueFinder(int numDigits)
        //{
        //    return new FirstValidValueFinder(new DescendingMultipleSupplier(numDigits), new PalindromeChecker());
        //}
    }
}
