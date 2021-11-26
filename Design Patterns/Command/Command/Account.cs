namespace Command
{
    internal class Account
    {
        private int balance;

        public int Balance => balance;

        public Account() => balance = 0;

        public void Deposit(int money)
        {
            if (money < 0) return;
            balance += money;
        }

        public void Withdraw(int money)
        {
            if(balance - money < 0) return;
            balance -= money;
        }
    }
}
