using BL;
using FluentAssertions;
using Xunit;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Test()
        {
            ServiceClient serviceClient = new ServiceClient();
            serviceClient.Service.GetServiceName().Should().Be("Service");
        }

        [Fact]
        public void TestEx()
        {
            ServiceExClient serviceClient = new ServiceExClient();
            serviceClient.Service.GetServiceName().Should().Be("ServiceEX");
        }

        [Fact]
        public void TestExParametrized()
        {
            ServiceExClientParametrized serviceClient = new ServiceExClientParametrized("ServiceEX parametrized");
            serviceClient.Service.GetServiceName().Should().Be("ServiceEX parametrized");
        }
    }
}