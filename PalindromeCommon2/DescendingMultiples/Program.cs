using PalindromeCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindromes.DescendingMultiples
{
    public class DescendingMultipleValueFinderFactory : IValueFinderFactory
    {
        public ValueFinderCreator CreateValueFinder { get; } =
            x => new FirstValidValueFinder(new DescendingMultipleSupplier(x), new PalindromeChecker());

        

        public void Run()
        {
            new PalindromeUI(this).RunUI();
        }

        
    }
}
