using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimplePalindromes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using PalindromeCommon;

namespace SimplePalindromes.Tests
{
    [TestClass()]
    public class SimpleHighestPalindromicMultipleFinderTests
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
            var target = new SimpleHighestPalindromicMultipleFinder(mockMultipleGenerator.Object, mockPalindromeChecker.Object);
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
            var target = new SimpleHighestPalindromicMultipleFinder(10, 99);
            long actual;

            // Act
            actual = target.FindValue();

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}