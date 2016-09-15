//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Palindromes
//{
//    public class BestIndexFinder<T> : IBestIndexFinder<T>
//    {
//        public delegate bool ValueComparer(T val1, T val2);

//        private readonly ValueComparer _comparer;
//        public BestIndexFinder(ValueComparer comparer)
//        {
//            _comparer = comparer;
//        }

//        public int FindIndex(IEnumerable<T> list)
//        {
//            int currentIndex = 0;
//            int bestIndex = -1;
//            T bestValue = default(T);
//            foreach(T value in list)
//            {
//                if (currentIndex == 0 || _comparer(value, bestValue))
//                {
//                    bestIndex = currentIndex;
//                    bestValue = value;
//                }
//                currentIndex++;
//            }
//            return bestIndex;
//        }
//    }
//}
