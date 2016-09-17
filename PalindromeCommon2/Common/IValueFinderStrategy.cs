using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindromes.Common
{
    //public delegate IValueFinder ValueFinderCreator(int numDigits);

    public interface IValueFinderStrategy
    {
        String Description { get; }
        IValueFinder CreateValueFinder(int numDigits);
    }
}
