using FluentAssertions;
using Part1;
using Xunit;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            "1".Should().Be("1");
        }
        [Fact]
        public void Test2()
        {
            SauceClient client = new SauceClient();
            client.GetIngredient().Name.Should().Be("French Sauce Bearnaise");
        }
    }
}