using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalindromeCommon
{
    public class Program
    {
        static void Main(string[] args)
        {
            Tuple<String, IValueFinderFactory>[] strategies =
            {
                new Tuple<string, IValueFinderFactory>("Generate all multiples of two N-digit numbers in arbitrary order, test each for palindromicity, and keep the highest palindrome found.",
                                                        new Palindromes.BruteForce.BruteForceValueFinderFactory()),
                new Tuple<string, IValueFinderFactory>("Generate multiples in descending order, and test for palindromicity until the first palindrome is found.",
                                                        new Palindromes.DescendingMultiples.DescendingMultipleValueFinderFactory()),
                new Tuple<string, IValueFinderFactory>("Generate palindromes in descending order, and test for factorability until the first multiple of two N-digit numbers is found.",
                                                        new Palindromes.DescendingPalindromes.DescendingPalindromeValueFinderFactory()),
                
            };

            PalindromeUI ui = new PalindromeUI(strategies);
            ui.RunUI();
        }

    }
}
