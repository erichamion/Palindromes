using Microsoft.VisualStudio.TestTools.UnitTesting;
using Palindromes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using PalindromeCommon;
using Palindromes.DescendingMultiples;

namespace Palindromes.DescendingMultiples.Tests
{
    [TestClass()]
    public class HighestPalindromicMultipleFinderTests
    {
        

        [TestMethod()]
        public void IntegrationTest_FindValueTest()
        {
            // Arrange
            long expected = 9009;
            var target = new FirstValidValueFinder(new DescendingMultipleSupplier(10, 99), new PalindromeChecker());
            long actual;

            // Act
            actual = target.FindValue();

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}