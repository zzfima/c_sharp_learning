namespace Command
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AccountImproved accountImproved = new AccountImproved();

            IOperation operation = new Withdraw(accountImproved, 30);
            operation.Execute();

            operation = new Withdraw(accountImproved, 50);
            operation.Execute();

            operation = new Deposit(accountImproved, 10);
            operation.Execute();
        }
    }
}
