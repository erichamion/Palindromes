using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Palindromes.Io;
using System.IO;

namespace Palindromes.Io.Tests
{
    [TestClass]
    public class UserOptionChooserTests
    {
        [TestMethod]
        public void GetOptionFromUserTest_WithoutFirstOptionNumber()
        {
            // Arrange
            var data = new Tuple<String, String>[]
            {
                new Tuple<String, String>("a", "Option 1"),
                new Tuple<String, String>("b", "Option 2"),
                new Tuple<String, String>("c", "Option 3"),
                new Tuple<String, String>("d", "Option 4"),
                new Tuple<String, String>("e", "Option 5"),
            };
            var index = 2;
            var expected = data[index - 1].Item2;
            String actual;
            var target = new UserOptionChooser();

            using (StringReader reader = new StringReader(index.ToString() + "\n"))
            {
                Console.SetIn(reader);


                // Act
                actual = target.GetOptionFromUser("", data, "");

            }
            // Assert
            Assert.AreSame(expected, actual);


            // Cleanup
            Console.SetIn(new StreamReader(Console.OpenStandardInput()));
        }


        [TestMethod]
        public void GetOptionFromUserTest_WithFirstOptionNumber()
        {
            // Arrange
            var data = new Tuple<String, String>[]
            {
                new Tuple<String, String>("a", "Option 1"),
                new Tuple<String, String>("b", "Option 2"),
                new Tuple<String, String>("c", "Option 3"),
                new Tuple<String, String>("d", "Option 4"),
                new Tuple<String, String>("e", "Option 5"),
            };
            var index = 2;
            var expected = data[index].Item2;
            String actual;
            var target = new UserOptionChooser();

            using (StringReader reader = new StringReader(index.ToString() + "\n"))
            {
                Console.SetIn(reader);


                // Act
                actual = target.GetOptionFromUser("", data, "", 0);

            }
            // Assert
            Assert.AreSame(expected, actual);


            // Cleanup
            Console.SetIn(new StreamReader(Console.OpenStandardInput()));
        }


        [TestMethod]
        public void GetOptionFromUserTest_WithBadInputs()
        {
            // Arrange
            var data = new Tuple<String, String>[]
            {
                new Tuple<String, String>("a", "Option 1"),
                new Tuple<String, String>("b", "Option 2"),
                new Tuple<String, String>("c", "Option 3"),
                new Tuple<String, String>("d", "Option 4"),
                new Tuple<String, String>("e", "Option 5"),
            };
            var startingOptionNumber = 3;
            var index = 2;
            var inputNumbers = new int[] { 2, 7, -1, 100, 0, index + startingOptionNumber};
            var inputStr = String.Join("\n", inputNumbers) + "\n";
            var expected = data[index].Item2;
            String actual;
            var target = new UserOptionChooser();

            using (StringReader reader = new StringReader(inputStr))
            {
                Console.SetIn(reader);


                // Act
                actual = target.GetOptionFromUser("", data, "", 0);

            }
            // Assert
            Assert.AreSame(expected, actual);


            // Cleanup
            Console.SetIn(new StreamReader(Console.OpenStandardInput()));
        }
    }
}
