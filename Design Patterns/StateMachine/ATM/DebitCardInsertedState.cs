namespace ATM
{
    public class DebitCardInsertedState : IAtmState
    {
        public string InsertDebitCard() => "You cannot insert the Debit Card, as the Debit card is already there";
        public string EjectDebitCard() => "Debit Card is ejected";
        public string EnterPin() => "Pin number has been entered correctly";
        public string WithdrawMoney() => "Money has been withdrawn";
    }
}