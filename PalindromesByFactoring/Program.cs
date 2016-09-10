using PalindromeCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalindromesByDescendingPalindromeGeneration
{
    public class Program : IValueFinderFactory
    {
        public ValueFinderCreator CreateValueFinder { get; } =
            factorDigits => new FirstValidValueFinder(new DescendingPalindromeSupplier(factorDigits * 2), new MultipleOfNDigitsChecker(factorDigits));

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
