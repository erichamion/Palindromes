using Microsoft.VisualStudio.TestTools.UnitTesting;
using Palindromes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Palindromes.DescendingMultiples;

namespace Palindromes.DescendingMultiples.Tests
{
    [TestClass()]
    public class DescendingMultipleValueFinderFactoryTests : Common.Tests.IValueFinderFactoryTests
    {
        [TestInitialize()]
        public override void SetTargetFactory()
        {
            TargetFactory = new Palindromes.DescendingMultiples.DescendingMultipleValueFinderFactory();
        }

        [TestMethod()]
        public override void CreateValueFinderTest()
        {
            base.CreateValueFinderTest();
        }
    }
}