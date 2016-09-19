using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindromes.Common
{
    public delegate IValueFinder ValueFinderFactory(int numDigits);

    public interface IValueFinderStrategy : IDescribable
    {
        ValueFinderFactory CreateValueFinder { get; }
    }
}
