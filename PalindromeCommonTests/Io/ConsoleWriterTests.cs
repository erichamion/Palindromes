using Microsoft.VisualStudio.TestTools.UnitTesting;
using Palindromes.Io;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindromes.Io.Tests
{
    [TestClass()]
    public class ConsoleWriterTests
    {
        [TestMethod()]
        public void WriteTest()
        {
            // Arrange
            var data = new String[] { "foo", "bar", "baz" };
            var expected = String.Join("", data);
            String actual;
            var target = new ConsoleWriter();

            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);

                // Act
                foreach (var datum in data)
                {
                    target.Write(datum);
                }
                actual = writer.ToString();
            }

            // Assert
            Assert.AreEqual(expected, actual);

            // Cleanup
            StreamWriter stdout = new StreamWriter(Console.OpenStandardOutput());
            stdout.AutoFlush = true;
            Console.SetOut(stdout);
        }

        [TestMethod()]
        public void WriteLineTest()
        {
            // Arrange
            var data = new String[] { "foo", "bar", "baz" };
            var expected = String.Join("\r\n", data) + "\r\n";
            String actual;
            var target = new ConsoleWriter();

            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);

                // Act
                foreach (var datum in data)
                {
                    target.WriteLine(datum);
                }
                actual = writer.ToString();
            }

            // Assert
            Assert.AreEqual(expected, actual);

            // Cleanup
            StreamWriter stdout = new StreamWriter(Console.OpenStandardOutput());
            stdout.AutoFlush = true;
            Console.SetOut(stdout);
        }
    }
}