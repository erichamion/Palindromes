using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindromes.Common
{
    public interface IDigitManipulator
    {
        int CountDigits(long value);
        int GetDigit(long value, int digit);
    }
}
