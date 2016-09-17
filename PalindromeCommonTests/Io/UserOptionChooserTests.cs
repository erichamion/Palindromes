using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Palindromes.Io;
using System.IO;
using Moq;
using Palindromes.Common;

namespace Palindromes.Io.Tests
{
    [TestClass]
    public class UserOptionChooserTests
    {
        [TestMethod]
        public void GetOptionFromUserTest_WithoutFirstOptionNumber()
        {
            // Arrange
            var data = new IDescribable[]
            {
                new Mock<IDescribable>().Object,
                new Mock<IDescribable>().Object,
                new Mock<IDescribable>().Object,
                new Mock<IDescribable>().Object,
                new Mock<IDescribable>().Object,
            };
            var index = 2;
            var expected = data[index];
            IDescribable actual;
            var mockOutputWriter = new Mock<IOutputWriter>();
            var mockInputReader = new Mock<IIntegerReader>();
            mockOutputWriter.Setup(x => x.Write(It.IsAny<String>()));
            mockOutputWriter.Setup(x => x.WriteLine(It.IsAny<String>()));
            mockInputReader.Setup(x => x.GetInt(1, data.Length)).Returns(index + 1);

            var target = new UserOptionChooser(mockOutputWriter.Object, mockInputReader.Object);

            // Act
            actual = target.GetOptionFromUser("", data);

            // Assert
            mockOutputWriter.Verify(x => x.WriteLine(It.IsAny<String>()), Times.AtLeast(data.Length));
            mockInputReader.Verify(x => x.GetInt(1, data.Length), Times.Once);
            Assert.AreSame(expected, actual);
        }


        [TestMethod]
        public void GetOptionFromUserTest_WithFirstOptionNumber()
        {
            // Arrange
            var data = new IDescribable[]
            {
                new Mock<IDescribable>().Object,
                new Mock<IDescribable>().Object,
                new Mock<IDescribable>().Object,
                new Mock<IDescribable>().Object,
                new Mock<IDescribable>().Object,
            };
            var index = 2;
            var startingOptionNumber = 27;
            var expected = data[index];
            IDescribable actual;
            var mockOutputWriter = new Mock<IOutputWriter>();
            var mockInputReader = new Mock<IIntegerReader>();
            mockOutputWriter.Setup(x => x.Write(It.IsAny<String>()));
            mockOutputWriter.Setup(x => x.WriteLine(It.IsAny<String>()));
            mockInputReader.Setup(x => x.GetInt(startingOptionNumber, startingOptionNumber + data.Length - 1)).Returns(index + startingOptionNumber);

            var target = new UserOptionChooser(mockOutputWriter.Object, mockInputReader.Object);          

            // Act
            actual = target.GetOptionFromUser("", data, startingOptionNumber);

            // Assert
            mockOutputWriter.Verify(x => x.WriteLine(It.IsAny<String>()), Times.AtLeast(data.Length));
            mockInputReader.Verify(x => x.GetInt(startingOptionNumber, startingOptionNumber + data.Length - 1), Times.Once);
            Assert.AreSame(expected, actual);
        }


        
    }
}
