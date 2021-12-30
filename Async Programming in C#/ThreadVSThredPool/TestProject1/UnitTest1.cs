using FluentAssertions;
using ThreadVSThreadPool;
using Xunit;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void TestConstructConcreteMixer1()
        {
            ConcreteMixer concreteMixer = new ConcreteMixer(11, 1);
            concreteMixer.ToString().Should().Be("ConcreteAmount: 11, WaterAmount: 1");
        }

        [Fact]
        public void TestConstructConcreteMixer2()
        {
            ConcreteMixer concreteMixer = new ConcreteMixer(44, 4.5);
            concreteMixer.ToString().Should().Be("ConcreteAmount: 44, WaterAmount: 4.5");
        }

        [Fact]
        public void TestNotEqualConcreteMixer()
        {
            ConcreteMixer concreteMixer1 = new ConcreteMixer(44, 4.5);
            ConcreteMixer concreteMixer2 = new ConcreteMixer(22, 2.5);
            concreteMixer1.Equals(concreteMixer2).Should().Be(false);
        }

        [Fact]
        public void TestEqualConcreteMixer()
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

        [Fact]
        public void TestGetHashCode()
        {
            ConcreteMixer concreteMixer1 = new ConcreteMixer(44, 4.5);
            concreteMixer1.GetHashCode().Should().Be(concreteMixer1.GetHashCode());
        }
    }
}