using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PalindromeCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalindromeCommon.Tests
{
    [TestClass()]
    public class FirstValidValueFinderTests
    {
        [TestMethod()]
        public void FindValueTest()
        {
            // Arrange
            long expected = 27;
            long mockNextValue = expected * 2;
            var mockMultipleGenerator = new Mock<AbstractValueSupplier<long>> { CallBase = true };
            mockMultipleGenerator.Setup(x => x.NextValue).Returns(() => mockNextValue--);
            mockMultipleGenerator.Setup(x => x.HasNext()).Returns(() => mockNextValue > 0);
            var mockPalindromeChecker = new Mock<IValueChecker<long>>();
            mockPalindromeChecker.Setup(x => x.IsValueValid(It.IsAny<long>())).Returns((long x) => x <= expected);
            var target = new FirstValidValueFinder(mockMultipleGenerator.Object, mockPalindromeChecker.Object);
            long actual;

            // Act
            actual = target.FindValue();

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}