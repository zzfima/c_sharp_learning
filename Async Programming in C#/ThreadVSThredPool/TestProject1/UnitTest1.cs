using System;
using FluentAssertions;
using ThreadVSThredPool;
using Xunit;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            ConcreteMixer concreteMixer = new ConcreteMixer(11, 1);
            concreteMixer.ToString().Should().Be("ConcreteAmount: 11, WaterAmount: 1");
        }

        [Fact]
        public void Test2()
        {
            ConcreteMixer concreteMixer = new ConcreteMixer(44, 4.5);
            concreteMixer.ToString().Should().Be("ConcreteAmount: 44, WaterAmount: 4.5");
        }

        [Fact]
        public void Test3()
        {
            ConcreteMixer concreteMixer1 = new ConcreteMixer(44, 4.5);
            ConcreteMixer concreteMixer2 = new ConcreteMixer(22, 2.5);
            concreteMixer1.Equals(concreteMixer2).Should().Be(false);
        }

        [Fact]
        public void Test4()
        {
            ConcreteMixer concreteMixer1 = new ConcreteMixer(44, 4.5);
            ConcreteMixer concreteMixer2 = new ConcreteMixer(44, 4.5);
            concreteMixer1.Equals(concreteMixer2).Should().Be(true);
        }

        [Fact]
        public void Test5()
        {
            ConcreteMixer concreteMixer1 = new ConcreteMixer(44, 4.5);
            ConcreteMixer concreteMixer2 = new ConcreteMixer(44, 4.5);
        }
    }
}
