using Microsoft.VisualStudio.TestTools.UnitTesting;
using Palindromes.BruteForce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Palindromes.Common;

namespace Palindromes.BruteForce.Tests
{
    [TestClass()]
    public class BruteForceHighestPalindromicMultipleFinderTests
    {
        [TestMethod()]
        public void UnitTest_FindValueTest()
        {
            // Arrange
            long expected = 27;
            long mockNextValue = expected * 2;
            var mockMultipleGenerator = new Mock<AbstractValueSupplier<long>> { CallBase = true };
            mockMultipleGenerator.Setup(x => x.NextValue).Returns(() => mockNextValue--);
            mockMultipleGenerator.Setup(x => x.HasNext()).Returns(() => mockNextValue > 0);
            var mockPalindromeChecker = new Mock<IValueChecker<long>>();
            mockPalindromeChecker.Setup(x => x.IsValueValid(It.IsAny<long>())).Returns((long x) => x <= expected);
            var target = new BruteForceHighestPalindromicMultipleFinder(mockMultipleGenerator.Object, mockPalindromeChecker.Object);
            long actual;

            // Act
            actual = target.FindValue();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void IntegrationTest_FindValueTest()
        {
            // Arrange
            long expected = 9009;
            var target = new BruteForceHighestPalindromicMultipleFinder(10, 99);
            long actual;

            // Act
            actual = target.FindValue();

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}