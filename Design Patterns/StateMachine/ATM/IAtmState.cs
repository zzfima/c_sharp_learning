namespace ATM
{
    public interface IAtmState
    {
        string InsertDebitCard();
        string EjectDebitCard();
        string EnterPin();
        string WithdrawMoney();
    }
}
