using Palindromes.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindromes.BruteForce
{
    public class BruteForceValueFinderFactory : IValueFinderStrategy
    {
        //public ValueFinderCreator CreateValueFinder { get; } =
        //    x => new BruteForceHighestPalindromicMultipleFinder(x);

        public string Description { get; } = 
            "Generate all multiples of two N-digit numbers in arbitrary order, test each for palindromicity, and keep the highest palindrome found.";

        IValueFinder IValueFinderStrategy.CreateValueFinder(int numDigits)
        {
            return new BruteForceHighestPalindromicMultipleFinder(numDigits);
        }
    }
}
