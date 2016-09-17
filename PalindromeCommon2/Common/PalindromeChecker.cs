using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindromes.Common
{
    public class PalindromeChecker : IValueChecker<long>
    {
        private readonly IDigitManipulator _digitManipulator;

        public PalindromeChecker() : this(new DigitManipulator()) { }

        public PalindromeChecker(IDigitManipulator digitManipulator)
        {
            _digitManipulator = digitManipulator;
        }

        public bool IsValueValid(long value)
        {
            // We could do something like:
            // return value.ToString().Equals(value.ToString().Reverse());


            // To avoid checking each pair of characters twice, we could do something like:
            //String valueStr = value.ToString();
            //for (int leftIndex = 0; leftIndex < valueStr.Length / 2; leftIndex++)
            //{
            //    int rightIndex = valueStr.Length - leftIndex - 1;
            //    if (valueStr[leftIndex] != valueStr[rightIndex])
            //    {
            //        return false;
            //    }
            //}
            //return true;


            // I'd like to avoid converting to string.
            int remainingDigits = _digitManipulator.CountDigits(value);
            long remainder = value;
            for (int lowIndex = 0; lowIndex < remainingDigits / 2; lowIndex++)
            {
                int highIndex = remainingDigits - lowIndex - 1;
                int lowDigit = _digitManipulator.GetDigit(remainder, lowIndex);
                int highDigit = _digitManipulator.GetDigit(remainder, highIndex);
                if (lowDigit != highDigit)
                {
                    return false;
                }
            }
            
            return true;
        }

        
    }
}
