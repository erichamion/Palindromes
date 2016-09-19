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
    public class NullValueFinderStrategyTests
    {
        [TestMethod()]
        public void DescriptionTest()
        {
            // Arrange
            var expected = "foo";
            String actual;
            var target = new NullValueFinderStrategy(expected);

            // Act
            actual = target.Description;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CreateValueFinderTest()
        {
            // Arrange
            ValueFinderFactory actual;
            var target = new NullValueFinderStrategy("foo");

            // Act
            actual = target.CreateValueFinder;

            // Assert
            Assert.IsNull(actual);
        }
    }
}