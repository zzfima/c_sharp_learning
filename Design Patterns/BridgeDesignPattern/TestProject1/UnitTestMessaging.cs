using Messaging.Core;
using NUnit.Framework;

namespace TestProject1
{
    public class UnitTestMessaging
    {
        [Test]
        public void TestThreadSchedulingWayName()
        {
            SendUsingWebService sendSms = new SendSMS();
            SendUsingWebService sendEmail = new SendEmail();

            Assert.AreEqual("SMS sent using CNN", sendSms.Send("CNN"));
            Assert.AreEqual("Email sent using KLL", sendEmail.Send("KLL"));
        }
    }
}