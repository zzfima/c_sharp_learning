using FluentAssertions;
using ReSharperTipsTricks;
using Xunit;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            MyClass myClass = new MyClass(2);
            myClass.VL = 7;
            myClass.VL.Should().Be(7);
        }

        [Fact]
        public void Test2()
        {
            MyClass myClass = new MyClass(66);
            myClass.MyMethod().Should().Be(66);
        }
    }
}
