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
        public void ShouldIngredientIsraeli()
        {
            SauceClient client = new SauceClient();
            client.GetIngredientIsraeli().Name.Should().Be("Israeli Middle East Sauce");
        }

        [Fact]
        public void ShouldIngredientBearnaise()
        {
            SauceClient client = new SauceClient();
            client.GetIngredientBearnaise().Name.Should().Be("French Sauce Bearnaise");
        }

        [Fact]
        public void ShouldIngredientDefault()
        {
            SauceClient client = new SauceClient();
            client.GetIngredientDefault().Name.Should().Be("French Sauce Bearnaise");
        }

        //[Fact]
        //public void Test3()
        //{
        //    SauceClient client = new SauceClient(true);
        //    client.GetIngredient().Name.Should().Be("French Sauce Bearnaise");
        //}
    }
}