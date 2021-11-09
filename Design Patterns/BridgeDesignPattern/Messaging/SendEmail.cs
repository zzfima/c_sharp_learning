namespace Messaging.Core
{
    public class SendEmail : ISendUsingWebService
    {
        public string Send(string senderMedium)
        {
            return "Email sent using " + senderMedium;
        }
    }
}
