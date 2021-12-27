using FluentAssertions;
using ReSharperTipsTricks;
using System.Threading;
using Xunit;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact, Trait("Speed", "Slow")]
        public void Test1()
        {
            MyClass myClass = new MyClass(2);
            myClass.Vl = 7;
            Thread.Sleep(500);
            myClass.Vl.Should().Be(7);
        }

        [Fact, Trait("Speed", "Fast")]
        public void Test2()
        {
            MyClass myClass = new MyClass(66);
            myClass.MyMethod().Should().Be(66);
        }

        [Fact, Trait("Speed", "Fast")]
        public void Test3()
        {
            MyClass myClass = new MyClass(66);
            myClass.MyMethod().Should().Be(66);
        }

        [Fact, Trait("Speed", "Fast")]
        public void Test4()
        {
            MyClass myClass = new MyClass(66);
            myClass.MyMethod().Should().Be(66);
        }
    }
}
