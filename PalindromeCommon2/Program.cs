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
            IValueFinderStrategy[] strategies =
            {
                new BruteForce.BruteForceValueFinderFactory(),
                new DescendingMultiples.DescendingMultipleValueFinderFactory(),
                new DescendingPalindromes.DescendingPalindromeValueFinderFactory(),
                
            };

            PalindromeUi ui = new PalindromeUi(strategies);
            ui.RunUI();
        }

    }
}
