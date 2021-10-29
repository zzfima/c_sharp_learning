using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        Duck _mallardDuck;
        Duck _redHeadDuck;
        Duck _rubberDuck;

        [TestInitialize]
        public void Init()
        {
            _mallardDuck = new MallardDuck();
            _redHeadDuck = new RedHeadDuck();
            _rubberDuck = new RubberDuck();
        }

        [TestCleanup]
        public void CleanUp()
        {
            _mallardDuck.Dispose();
            _redHeadDuck.Dispose();
        }

        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(_mallardDuck.Dislay(), "I am Mallard Duck");
        }

        [TestMethod]
        public void TestMethod2()
        {
            Assert.AreEqual(_rubberDuck.Swim(), "Can not swim");
        }
    }
}
