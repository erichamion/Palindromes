using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindromes.DescendingPalindromes.Tests
{
    [TestClass()]
    public class DescendingPalindromeValueFinderFactoryTests : Common.Tests.IValueFinderFactoryTests
    {
        [TestInitialize()]
        public override void SetTargetFactory()
        {
            TargetFactory = new DescendingPalindromeValueFinderFactory();
        }

        [TestMethod()]
        public override void CreateValueFinderTest()
        {
            base.CreateValueFinderTest();
        }
    }
}