namespace Messaging.Core
{
    public class SendSMS : SendUsingWebService
    {
        public override string Send(string senderMedium)
        {
            return "SMS sent using " + senderMedium;
        }
    }
}
