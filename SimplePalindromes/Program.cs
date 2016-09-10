using PalindromeCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplePalindromes
{
    public class Program : IValueFinderFactory
    {
        public ValueFinderCreator CreateValueFinder { get; } =
            x => new SimpleHighestPalindromicMultipleFinder(x);

        static void Main(string[] args)
        {
            new Program().Run();
        }

        public void Run()
        {
            new PalindromeUI(this).RunUI();
        }
    }
}
