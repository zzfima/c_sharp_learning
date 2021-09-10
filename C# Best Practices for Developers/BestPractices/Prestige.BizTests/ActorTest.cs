using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prestige.Biz;

namespace Prestige.BizTests
{
    [TestClass]
    public class ActorTest
    {
        [TestMethod]
        public void TestOccupation()
        {
            //Arrange
            Actor actor = new Actor();

            //Act
            string occupation = actor.GetOccupation();

            //Assert
            Assert.AreEqual(occupation, "Actor");
        }
    }
}
