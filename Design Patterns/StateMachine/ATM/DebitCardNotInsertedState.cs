namespace ATM
{
    public class DebitCardNotInsertedState : IAtmState
    {
        public string InsertDebitCard() => "Debit Card Inserted";
        public string EjectDebitCard() => "You cannot eject the Debit Card, as no Debit Card in ATM Machine slot";
        public string EnterPin() => "You cannot enter the pin, as no Debit Card in ATM Machine slot";
        public string WithdrawMoney() => "You cannot withdraw money, as no Debit Card in ATM Machine slot";
    }
}