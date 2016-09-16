using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
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
    public class ConsoleReaderWithPromptTests
    {
        [TestMethod()]
        public void GetIntTest_ValidInput()
        {
            // Arrange
            var expected = 27;
            int actual;
            var prompt = " > ";
            var mockOutputWriter = new Mock<IOutputWriter>();
            mockOutputWriter.Setup(x => x.Write(prompt));
            var target = new ConsoleReaderWithPrompt(prompt, "", mockOutputWriter.Object);

            using (var reader = new StringReader(expected.ToString() + "\n"))
            {
                Console.SetIn(reader);


                // Act
                actual = target.GetInt();

            }

            // Assert
            mockOutputWriter.Verify(x => x.Write(prompt), Times.Once);
            Assert.AreEqual(expected, actual);


            // Cleanup
            Console.SetIn(new StreamReader(Console.OpenStandardInput()));
        }

        [TestMethod()]
        public void GetIntTest_InvalidInput()
        {
            // Arrange
            var expected = 27;
            var data = new String[]
            {
                "Not a number",
                "32.5",
                "*",
                expected.ToString(),
            };
            int actual;
            var prompt = " > ";
            var invalidMessage = "foo";
            var mockOutputWriter = new Mock<IOutputWriter>();
            mockOutputWriter.Setup(x => x.Write(prompt));
            mockOutputWriter.Setup(x => x.WriteLine(invalidMessage));
            var target = new ConsoleReaderWithPrompt(prompt, invalidMessage, mockOutputWriter.Object);

            using (var reader = new StringReader(String.Join("\n", data) + "\n"))
            {
                Console.SetIn(reader);


                // Act
                actual = target.GetInt();

            }

            // Assert
            mockOutputWriter.Verify(x => x.Write(prompt), Times.Exactly(data.Length));
            mockOutputWriter.Verify(x => x.WriteLine(invalidMessage), Times.Exactly(data.Length - 1));
            Assert.AreEqual(expected, actual);


            // Cleanup
            Console.SetIn(new StreamReader(Console.OpenStandardInput()));
        }

        [TestMethod()]
        public void GetStringTest()
        {
            // Arrange
            var expected = "I am a string";
            String actual;
            var prompt = " > ";
            var mockOutputWriter = new Mock<IOutputWriter>();
            mockOutputWriter.Setup(x => x.Write(prompt));
            var target = new ConsoleReaderWithPrompt(prompt, "", mockOutputWriter.Object);

            using (var reader = new StringReader(expected + "\n"))
            {
                Console.SetIn(reader);


                // Act
                actual = target.GetString();

            }

            // Assert
            mockOutputWriter.Verify(x => x.Write(prompt), Times.Once);
            Assert.AreEqual(expected, actual);


            // Cleanup
            Console.SetIn(new StreamReader(Console.OpenStandardInput()));
        }
    }
}