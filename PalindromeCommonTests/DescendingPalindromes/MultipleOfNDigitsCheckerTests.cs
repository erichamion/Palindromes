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
    public class MultipleOfNDigitsCheckerTests
    {
        
        [TestMethod()]
        public void IsValidValue_ValidValue_ReturnsTrue()
        {
            // Arrange
            long data = 9009;
            bool expected = true;
            bool actual;
            var target = new MultipleOfNDigitsChecker(2);

            // Act
            actual = target.IsValueValid(data);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void IsValidValue_InvalidValue_ReturnsFalse()
        {
            // Arrange
            long data = 9999;
            bool expected = false;
            bool actual;
            var target = new MultipleOfNDigitsChecker(2);

            // Act
            actual = target.IsValueValid(data);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        
    }
}