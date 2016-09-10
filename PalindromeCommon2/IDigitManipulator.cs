using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalindromeCommon
{
    public interface IDigitManipulator
    {
        int CountDigits(long value);
        int GetDigit(long value, int digit);
    }
}
