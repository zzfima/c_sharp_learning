using System.ComponentModel;
using System.Threading;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringKataCalculator;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod, TestCategory("Fast")]
        public void ShouldReturnZeroWhenNoArguments()
        {
            //Arrange
            var stringCalculator = new StringCalculator();

            //Act
            var addResult = stringCalculator.Add("");

            //Assert
            addResult.Should().Be(0);
        }


        [TestMethod, TestCategory("slow")]
        public void ShouldReturnOneWhenArgumentOne()
        {
            //Arrange
            var stringCalculator = new StringCalculator();

            //Act
            var addResult = stringCalculator.Add("1");
            Thread.Sleep(1000);

            //Assert
            addResult.Should().Be(1);
        }
    }
}
