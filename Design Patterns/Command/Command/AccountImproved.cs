using System;

namespace Command
{
    public class AccountImproved
    {
        public int Balance { get; set; }
    }

    public interface IOperation
    {
        void Execute();
        bool IsComplete { get; }
    }

    public class Withdraw : IOperation
    {
        private AccountImproved _accountImproved;
        private int _money;
        private bool _isComplete;

        public bool IsComplete { get => _isComplete; }

        public Withdraw(AccountImproved accountImproved, int money)
        {
            _accountImproved = accountImproved;
            _money = money;
            _isComplete = false;
        }

        public void Execute()
        {
            _accountImproved.Balance += _money;
            _isComplete = true;
            Console.WriteLine($"Withdrawn {_money} dollars. Balance: {_accountImproved.Balance}");
        }
    }

    public class Deposit : IOperation
    {
        private bool _isComplete;
        private AccountImproved _accountImproved;
        private int _money;

        public bool IsComplete { get => _isComplete; }

        public Deposit(AccountImproved accountImproved, int money)
        {
            _accountImproved = accountImproved;
            _money = money;
            _isComplete = false;
            Console.WriteLine($"Deposit {_money} dollars. Balance: {_accountImproved.Balance}");
        }

        public void Execute()
        {
            _accountImproved.Balance += _money;
            _isComplete = true;
        }
    }
}
