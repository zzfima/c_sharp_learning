using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prestige.Biz;
using System;

namespace Prestige.BizTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Actor actor = new Actor();
            Assert.AreEqual(actor.GetOccupation(), "Actor");
        }
    }
}
