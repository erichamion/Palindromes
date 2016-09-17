using Palindromes.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindromes.DescendingPalindromes
{
    public class DescendingPalindromeSupplier : AbstractValueSupplier<long>
    {
        private readonly INumberMirrorer _mirrorer;
        private readonly AbstractDigitListSupplier _digitListSupplier;
        private int _fullPalindromeNumDigits;
        private IEnumerable<int> _lastDigitList;

        public DescendingPalindromeSupplier(int numDigits)
            : this(numDigits, new NumberMirrorer())
        { }

        public DescendingPalindromeSupplier(int numDigits, AbstractDigitListSupplier digitListSupplier)
            : this(numDigits, digitListSupplier, new NumberMirrorer())
        { }

        public DescendingPalindromeSupplier(int numDigits, INumberMirrorer mirrorer)
            : this(numDigits, new DescendingDigitListSupplier(numDigits), mirrorer)
            { }

        public DescendingPalindromeSupplier(int numDigits, AbstractDigitListSupplier digitListSupplier, INumberMirrorer mirrorer)
        {
            _mirrorer = mirrorer;

            _digitListSupplier = digitListSupplier;
            _fullPalindromeNumDigits = numDigits;
            SetDigitSupplierDigits();
        }

        public override long NextValue
        {
            get
            {
                if (!_digitListSupplier.HasNext())
                {
                    DropDigit();
                }
                _lastDigitList = _digitListSupplier.NextValue;
                return _mirrorer.Mirror(_lastDigitList, _fullPalindromeNumDigits % 2 == 1);
            }
        }

        public override bool HasNext()
        {
            bool hasRunOut = _fullPalindromeNumDigits == 0
                || (_fullPalindromeNumDigits == 1 && _lastDigitList != null && _lastDigitList.SequenceEqual(new int[] { 1 }));
            return !hasRunOut;
        }


        

        private void DropDigit()
        {
            _fullPalindromeNumDigits--;
            SetDigitSupplierDigits();
        }

        private void SetDigitSupplierDigits()
        {
            _digitListSupplier.Reset(_fullPalindromeNumDigits / 2 + _fullPalindromeNumDigits % 2);
        }
    }
    
}
