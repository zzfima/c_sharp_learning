using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using StringKataCalculator;
using Xunit;
using FluentAssertions;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Arrange
            var stringCalculator = new StringCalculator();

            //Act
            var addResult = stringCalculator.Add("");

            //Assert
            addResult.Should().Be(0);
        }
    }
}
