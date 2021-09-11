using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prestige.Common;

namespace Prestige.CommonTests
{
    [TestClass]
    public class NotificationServiceTest
    {
        [TestMethod]
        public void TestNotifyTalent()
        {
            //Arrange
            string expected = "Notifying talent: Moshe";
            string talentName = "Moshe";

            //Act
            string actual = NotificationService.NotifyTalent(talentName);

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
