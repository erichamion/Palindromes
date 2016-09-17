using Palindromes.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindromes
{
    public class Program
    {
        static void Main(string[] args)
        {
            Tuple<String, IValueFinderStrategy>[] strategies =
            {
                new Tuple<string, IValueFinderStrategy>("Generate all multiples of two N-digit numbers in arbitrary order, test each for palindromicity, and keep the highest palindrome found.",
                                                        new BruteForce.BruteForceValueFinderFactory()),
                new Tuple<string, IValueFinderStrategy>("Generate multiples in descending order, and test for palindromicity until the first palindrome is found.",
                                                        new DescendingMultiples.DescendingMultipleValueFinderFactory()),
                new Tuple<string, IValueFinderStrategy>("Generate palindromes in descending order, and test for factorability until the first multiple of two N-digit numbers is found.",
                                                        new DescendingPalindromes.DescendingPalindromeValueFinderFactory()),
                
            };

            PalindromeUi ui = new PalindromeUi(strategies);
            ui.RunUI();
        }

    }
}
