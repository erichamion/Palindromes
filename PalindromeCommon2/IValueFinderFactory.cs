using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalindromeCommon
{
    public delegate IValueFinder ValueFinderCreator(int numDigits);

    public interface IValueFinderFactory
    {
        ValueFinderCreator CreateValueFinder { get; }
    }
}
