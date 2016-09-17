using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindromes.BruteForce.Tests
{
    [TestClass()]
    public class ProgramTests : PalindromeCommon.Tests.IValueFinderFactoryTests
    {
        [TestInitialize()]
        public override void SetTargetFactory()
        {
            TargetFactory = new BruteForceValueFinderFactory();
        }

        [TestMethod()]
        public override void CreateValueFinderTest()
        {
            base.CreateValueFinderTest();
        }
    }
}