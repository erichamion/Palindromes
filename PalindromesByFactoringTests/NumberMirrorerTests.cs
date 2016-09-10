using Microsoft.VisualStudio.TestTools.UnitTesting;
using PalindromesByDescendingPalindromeGeneration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalindromesByDescendingPalindromeGeneration.Tests
{
    [TestClass()]
    public class NumberMirrorerTests
    {
        [TestMethod()]
        public void MirrorTest()
        {
            // Arrange
            var expecteds = new long[] { 54345, 1221, 9, 99 };
            var data = new Tuple<int[], bool>[] {
                new Tuple<int[], bool>(new int[] { 3, 4, 5 }, true),
                new Tuple<int[], bool>(new int[] { 2, 1 }, false),
                new Tuple<int[], bool>(new int[] { 9 }, true),
                new Tuple<int[], bool>(new int[] { 9 }, false),
            };
            var actuals = new long[data.Length];
            var target = new NumberMirrorer();

            // Act
            for (int i = 0; i < data.Length; i++)
            {
                actuals[i] = target.Mirror(data[i].Item1, data[i].Item2);
            }


            // Assert
            Assert.IsTrue(expecteds.SequenceEqual(actuals));
        }
    }
}