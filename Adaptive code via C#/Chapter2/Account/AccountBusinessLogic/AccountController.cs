namespace AccountBusinessLogic
{
    public class AccountController
    {
        private readonly SecurityService securityService;

        public AccountController()
        {
            this.securityService = new SecurityService();
        }

        public void ChangePassword(long userId, string newPassword)
        {
            var userRepository = new UserRepository();
            var user = userRepository.GetById(userId);
            this.securityService.ChangePassword(user, newPassword);
        }
    }
}
