namespace Messaging.Core
{
    public class SendEmail : SendUsingWebService
    {
        public override string Send(string senderMedium)
        {
            return "Email sent using " + senderMedium;
        }
    }
}
