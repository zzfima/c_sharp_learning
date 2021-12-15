using FluentAssertions;
using StringKataCalculator;
using Xunit;

namespace TestProjectStringCalculator
{
    public class UnitTest1
    {
        [Fact]
        public void ShouldReturn0ForEmpty()
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
