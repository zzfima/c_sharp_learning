using System;

namespace AccountBusinessLogic
{
    internal class SecurityService
    {
        public SecurityService()
        {
            this.Session = SessionFactory.GetSession();
        }

        public object Session { get; }

        internal void ChangePassword(object user, string newPassword)
        {
            throw new NotImplementedException();
        }
    }
}