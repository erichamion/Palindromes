//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using PalindromesByDescendingPalindromeGeneration;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace PalindromesByDescendingPalindromeGeneration.Tests
//{
//    [TestClass()]
//    public class DescendingDigitListSupplierTests
//    {
//        [TestMethod()]
//        public void DescendingDigitListSupplierTest()
//        {
//            // Arrange
//            IEnumerable<IEnumerable<int>> expected = Enumerable.Range(10, 90)
//                .Reverse()
//                .Select(x => x.ToString())
//                .Select(x => new int[] { (int)Char.GetNumericValue(x[1]), (int)Char.GetNumericValue(x[0]) });
//            var target = new DescendingDigitListSupplier(2);
//            List<IEnumerable<int>> actual = new List<IEnumerable<int>>();
//            IEnumerable<bool> comparisons = new bool[expected.Count()];


//            // Act
//            foreach (var value in target)
//            {
//                actual.Add(value);
//            }
//            comparisons = expected.Zip(actual, (x, y) => x.SequenceEqual(y));

//            // Assert
//            Assert.AreEqual(expected.Count(), actual.Count);

//            Assert.IsTrue(comparisons.All(x => x));
//        }

//        [TestMethod()]
//        public void ResetTest_NoParams()
//        {
//            // Arrange
//            var expected = new int[] { 9, 9 };
//            var target = new DescendingDigitListSupplier(2);
//            IEnumerable<int> actual;
//            IEnumerable<bool> comparisons = new bool[expected.Count()];


//            // Act
//            foreach (var value in target)
//            {
//                // Go through all the values 
//            }
//            target.Reset();
//            actual = target.NextValue;

//            // Assert
//            Assert.IsTrue(expected.SequenceEqual(actual));
//        }

//        [TestMethod()]
//        public void ResetTest_WithParam()
//        {
//            // Arrange
//            var expected = new int[] { 9, 9, 9, 9, 9 };
//            var target = new DescendingDigitListSupplier(2);
//            IEnumerable<int> actual;
//            IEnumerable<bool> comparisons = new bool[expected.Count()];


//            // Act
//            foreach (var value in target)
//            {
//                // Go through all the values 
//            }
//            target.Reset(5);
//            actual = target.NextValue;

//            // Assert
//            Assert.IsTrue(expected.SequenceEqual(actual));
//        }
//    }
//}