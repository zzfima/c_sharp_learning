using System;

namespace Prestige.Common
{
    static public class NotificationService
    {
        static public string NotifyTalent(string talentName)
        {
            string msg = "Notifying talent: " + talentName;
            Console.WriteLine(msg);
            return msg;
        }
    }
}
