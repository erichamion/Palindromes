using Microsoft.VisualStudio.TestTools.UnitTesting;
using Palindromes;
using Palindromes.DescendingMultiples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindromes.DescendingMultiples.Tests
{
    [TestClass()]
    public class DescendingMultipleSupplierTests
    {
        [TestMethod()]
        public void DescendingMultipleSupplierTest_DirectUsage_GivesAllSortedResults()
        {
            // Arrange
            List<long> expected = new List<long>();
            for (int left = 10; left < 100; left++)
            {
                for (int right = 10; right <= left; right++)
                {
                    expected.Add(left * right);
                }
            }
            expected.Sort();
            expected.Reverse();
            List<long> actual = new List<long>();
            DescendingMultipleSupplier target = new DescendingMultipleSupplier(10, 99);

            // Act
            for (int i = 0; i < expected.Count; i++)
            {
                actual.Add(target.NextValue);
            }

            // Assert
            Assert.IsTrue(expected.SequenceEqual(actual));
        }

        [TestMethod()]
        public void DescendingMultipleSupplierTest_Foreach_GivesAllSortedResults()
        {
            // Arrange
            List<long> expected = new List<long>();
            for (int left = 10; left < 100; left++)
            {
                for (int right = 10; right <= left; right++)
                {
                    expected.Add(left * right);
                }
            }
            expected.Sort();
            expected.Reverse();
            List<long> actual = new List<long>();
            DescendingMultipleSupplier target = new DescendingMultipleSupplier(10, 99);

            // Act
            foreach (long x in target)
            {
                actual.Add(x);
            }

            // Assert
            Assert.IsTrue(expected.SequenceEqual(actual));
        }
    }
}