using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalindromeCommon
{
    public class DigitManipulator : IDigitManipulator
    {
        public int CountDigits(long value)
        {
            // Log10(1) is 0
            // Log10(2-9) is between 0 and 1  
            // Log10(10) is 1
            // Log10(11-99) is between 1 and 2
            // Log10(100) is 2

            return (int)Math.Ceiling(Math.Log10(value + 1));
        }

        public int GetDigit(long value, int digit)
        {
            long remaining = value;
            for (int i = 0; i < digit; i++)
            {
                remaining /= 10;
            }

            return (int)(remaining % 10);
        }
    }
}
