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
                new Tuple<string, IValueFinderFactory>("Generate multiples in descending order, and test for palindromicity.",
                                                        new Palindromes.DescendingMultiples.DescendingMultipleValueFinderFactory()),
                new Tuple<string, IValueFinderFactory>("Generate palindromes in descending order, and test for factorability.",
                                                        new Palindromes.DescendingPalindromes.DescendingPalindromeValueFinderFactory()),
            };

            PalindromeUI ui = new PalindromeUI(strategies);
            ui.RunUI();
        }

    }
}
