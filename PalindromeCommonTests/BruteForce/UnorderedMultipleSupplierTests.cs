using Microsoft.VisualStudio.TestTools.UnitTesting;
using Palindromes.BruteForce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindromes.BruteForce.Tests
{
    [TestClass()]
    public class UnorderedMultipleSupplierTests
    {
        [TestMethod()]
        public void UnorderedMultipleSupplierTest_DirectUsage_GivesAllPossibleResults()
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
            List<long> actual = new List<long>();
            UnorderedMultipleSupplier target = new UnorderedMultipleSupplier(10, 99);

            // Act
            for (int i = 0; i < expected.Count; i++)
            {
                actual.Add(target.NextValue);
            }
            actual.Sort();

            // Assert
            Assert.IsTrue(expected.SequenceEqual(actual));
        }

        [TestMethod()]
        public void UnorderedMultipleSupplierTest_Foreach_GivesAllPossibleResults()
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
            List<long> actual = new List<long>();
            UnorderedMultipleSupplier target = new UnorderedMultipleSupplier(10, 99);

            // Act
            foreach (long x in target)
            {
                actual.Add(x);
            }
            actual.Sort();

            // Assert
            Assert.IsTrue(expected.SequenceEqual(actual));
        }
    }
}