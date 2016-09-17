using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Palindromes.Common;

namespace Palindromes.Common.Tests
{
    [TestClass()]
    public abstract class IValueFinderFactoryTests
    {
        protected IValueFinderStrategy TargetFactory { get; set; }

        [TestInitialize]
        public abstract void SetTargetFactory();

        [TestMethod()]
        public virtual void CreateValueFinderTest()
        {
            // Arrange
            int data = 2;
            long expected = 9009;
            long actual;
            var target = TargetFactory.CreateValueFinder(data);

            // Act
            actual = target.FindValue();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        
    }
}