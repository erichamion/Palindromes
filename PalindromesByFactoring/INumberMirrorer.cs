using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalindromesByDescendingPalindromeGeneration
{
    public interface INumberMirrorer
    {
        long Mirror(IEnumerable<int> digits, bool resultHasOddDigits);
    }
}
