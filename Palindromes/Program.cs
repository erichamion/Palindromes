using PalindromeCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindromes
{
    public class Program : IValueFinderFactory
    {
        public ValueFinderCreator CreateValueFinder { get; } =
            x => new FirstValidValueFinder(new DescendingMultipleSupplier(x), new PalindromeChecker());

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
