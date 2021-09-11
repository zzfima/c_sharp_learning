using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prestige.Common;

namespace Prestige.CommonTests
{
    [TestClass]
    public class PolicyTest
    {
        [TestMethod]
        public void TestLevel()
        {
            //Arrange
            string expected = "Level is: Low Load";

            //Act
            Policy.Instance.Level = "High Load";
            Policy.Instance.Level = "Low Load";
            string actual = Policy.Instance.Level;

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
