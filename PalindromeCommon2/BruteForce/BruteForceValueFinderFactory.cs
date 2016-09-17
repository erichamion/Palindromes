using Palindromes.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindromes.BruteForce
{
    public class BruteForceValueFinderFactory : IValueFinderFactory
    {
        public ValueFinderCreator CreateValueFinder { get; } =
            x => new BruteForceHighestPalindromicMultipleFinder(x);
    }
}
