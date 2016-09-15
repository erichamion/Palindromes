//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Palindromes;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Palindromes.Tests
//{
//    [TestClass()]
//    public class BestIndexFinderTests
//    {
//        [TestMethod()]
//        public void FindIndexTest()
//        {
//            // Arrange
//            var data = new List<int> { 1, 3, 5, 7, 9, 8, 6, 4, 2, 0 };
//            var target1 = new BestIndexFinder<int>((x, y) => x > y);
//            var target2 = new BestIndexFinder<int>((x, y) => x < y);
//            int expected1 = 4;
//            int expected2 = 9;
//            int actual1;
//            int actual2;

//            // Act
//            actual1 = target1.FindIndex(data);
//            actual2 = target2.FindIndex(data);

//            // Assert
//            Assert.AreEqual(expected1, actual1);
//            Assert.AreEqual(expected2, actual2);
//        }
//    }
//}