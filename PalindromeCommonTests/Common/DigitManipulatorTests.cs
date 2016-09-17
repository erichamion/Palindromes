using Microsoft.VisualStudio.TestTools.UnitTesting;
using Palindromes.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindromes.Common.Tests
{
    [TestClass()]
    public class DigitManipulatorTests
    {
        [TestMethod()]
        public void CountDigitsTest()
        {
            // Arrange
            long data = 456789;
            int expected = 6;
            int actual;
            var target = new DigitManipulator();

            // Act
            actual = target.CountDigits(data);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void GetDigitTest()
        {
            // Arrange
            long param1 = 456789;
            int param2 = 2;
            int expected = 7;
            int actual;
            var target = new DigitManipulator();

            // Act
            actual = target.GetDigit(param1, param2);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}