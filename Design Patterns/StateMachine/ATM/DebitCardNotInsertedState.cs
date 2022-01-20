namespace ATM
{
    public class DebitCardNotInsertedState : IAtmState
    {
        public string InsertDebitCard() => "DebitCard Inserted";
        public string EjectDebitCard() => "You cannot eject the Debit CardNo, as no Debit Card in ATM Machine slot";
        public string EnterPin() => "You cannot enter the pin, as No Debit Card in ATM Machine slot";
        public string WithdrawMoney()=> "You cannot withdraw money, as No Debit Card in ATM Machine slot";
    }
}
