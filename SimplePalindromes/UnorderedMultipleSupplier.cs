//using PalindromeCommon;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace SimplePalindromes
//{
//    public class UnorderedMultipleSupplier : AbstractValueSupplier<long>
//    {
//        private long _leftFactor;
//        private long _rightFactor;
//        private long _maxFactor;

//        public UnorderedMultipleSupplier(int min, int max)
//        {
//            _maxFactor = max;
//            _leftFactor = min;
//            _rightFactor = min;
//        }

//        public UnorderedMultipleSupplier(int numDigits) : this((int)Math.Pow(10, numDigits - 1), (int)Math.Pow(10, numDigits) - 1)
//        { }

//        public override long NextValue
//        {
//            get
//            {
//                long result = _leftFactor * _rightFactor;
//                IncrementRightFactor();
//                return result;
//            }
//        }

//        public override bool HasNext()
//        {
//            return _leftFactor <= _maxFactor;
//        }

//        private void IncrementRightFactor()
//        {
//            if (++_rightFactor > _maxFactor)
//            {
//                _rightFactor = ++_leftFactor;
//            }
//        }
//    }
//}
