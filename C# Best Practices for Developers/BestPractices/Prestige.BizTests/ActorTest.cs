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
            string expected = "Actor";

            //Act
            string result = actor.GetOccupation();

            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestJobTitle()
        {
            //Arrange
            Actor actor = new Actor();
            string job = "superman";

            //Act
            actor.JobTitle = job;

            //Assert
            Assert.AreEqual(job, actor.JobTitle);
        }
    }
}
