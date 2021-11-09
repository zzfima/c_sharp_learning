namespace Messaging.Core
{
    public class SendSMS : ISendUsingWebService
    {
        public string Send(string senderMedium)
        {
            return "SMS sent using " + senderMedium;
        }
    }
}
