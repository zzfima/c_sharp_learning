using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringKataCalculator;
using System.Threading;

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
            Thread.Sleep(10);
            //Assert
            addResult.Should().Be(1);
        }
        
        [TestMethod, TestCategory("slow")]
        public void ShouldReturn10WhenArgumentsAre5And5()
        {
            //Arrange
            var stringCalculator = new StringCalculator();

            //Act
            var addResult = stringCalculator.Add("5,5");

            //Assert
            addResult.Should().Be(10);
        }
        [TestMethod, TestCategory("slow")]
        public void ShouldReturn100WhenArgumentsAre25FourTimes()
        {
            //Arrange
            var stringCalculator = new StringCalculator();

            //Act
            var addResult = stringCalculator.Add("25, 25, 25,25");

            //Assert
            addResult.Should().Be(100);
        }
    }
}