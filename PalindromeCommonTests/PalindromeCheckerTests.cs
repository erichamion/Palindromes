using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using PalindromeCommon;

namespace PalindromeCommon.Tests
{
    [TestClass()]
    public class PalindromeCheckerTests
    {
        [TestMethod()]
        public void IsPalindromeTest_ValidPalindrome_ReturnsTrue()
        {
            // Arrange
            long data = 1234321;
            bool expected = true;
            bool actual;
            var target = new PalindromeChecker();

            // Act
            actual = target.IsValueValid(data);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void IsPalindromeTest_InvalidPalindrome_ReturnsFalse()
        {
            // Arrange
            long data = 54325;
            bool expected = false;
            bool actual;
            var target = new PalindromeChecker();

            // Act
            actual = target.IsValueValid(data);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void IsPalindromeTest_UsesIDigitManipulator()
        {
            // Arrange
            int numDigits = -1;
            var mockDigitManipulator = new Mock<IDigitManipulator>();
            mockDigitManipulator.Setup(x => x.CountDigits(It.IsAny<long>())).Returns((long x) => (int) x).Callback((long x) => numDigits = (int) x);
            mockDigitManipulator.Setup(x => x.GetDigit(It.IsAny<long>(), It.IsAny<int>())).Returns(4);
            var target = new PalindromeChecker(mockDigitManipulator.Object);
            bool result;

            // Act
            result = target.IsValueValid(35);

            // Assert
            mockDigitManipulator.Verify(x => x.CountDigits(It.IsAny<long>()), Times.Once);
            mockDigitManipulator.Verify(x => x.GetDigit(It.IsAny<long>(), It.IsAny<int>()), Times.Between(numDigits - 1, numDigits, Range.Inclusive));
            Assert.IsTrue(result);
            
        }
    }
}