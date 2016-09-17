using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindromes.Common
{
    /// <summary>
    /// This was originally called HighestPalindromicMultipleFinder, and it was used only in
    /// the initial Palindromes project. The AbstractValueSupplier was called _multipleSupplier,
    /// and the IValueChecker was called _palindromeChecker.
    /// Then when creating PalindromesByFactoring, I saw that it could use this unchanged, but
    /// the roles of the supplier and checker were reversed (instead of supplying multiples and
    /// checking whether they're palindromes, we would supply palindromes and check whether they're
    /// multiples), so I made the names more general.
    /// </summary>
    public class FirstValidValueFinder : IValueFinder
    {
        private readonly AbstractValueSupplier<long> _valueSupplier;
        private readonly IValueChecker<long> _valueChecker;

        public FirstValidValueFinder(AbstractValueSupplier<long> valueSupplier, IValueChecker<long> valueChecker)
        {
            _valueSupplier = valueSupplier;
            _valueChecker = valueChecker;
        }

        public long FindValue()
        {
            long result = 0;
            foreach (long val in _valueSupplier)
            {
                if (_valueChecker.IsValueValid(val))
                {
                    result = val;
                    break;
                }
            }

            return result;
        }
    }
}
