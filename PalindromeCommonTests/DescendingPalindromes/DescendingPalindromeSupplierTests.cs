using Microsoft.VisualStudio.TestTools.UnitTesting;
using Palindromes.DescendingPalindromes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindromes.DescendingPalindromes.Tests
{
    [TestClass()]
    public class DescendingPalindromeSupplierTests
    {
        [TestMethod()]
        public void DescendingPalindromeSupplierTest()
        {
            // Arrange
            var startingExpecteds = new long[] {
                999, 989, 979, 969, 959, 949, 939, 929, 919, 909,
                898, 888, 878, 868, 858, 848, 838, 828, 818, 808
            };
            var endingExpecteds = new long[] {
                99, 88, 77, 66, 55, 44, 33, 22, 11,
                9,  8,  7,  6,  5,  4,  3,  2,  1
            };
            IEnumerable<long> actuals;
            IEnumerable<long> startingActuals;
            IEnumerable<long> endingActuals;
            var target = new DescendingPalindromeSupplier(3);

            // Act
            actuals = target.ToList();
            startingActuals = actuals.Take(startingExpecteds.Length);
            endingActuals = actuals.Reverse().Take(endingExpecteds.Length).Reverse();


            // Assert
            Assert.IsTrue(startingExpecteds.SequenceEqual(startingActuals));
            Assert.IsTrue(endingExpecteds.SequenceEqual(endingActuals));
        }
        
    }
}