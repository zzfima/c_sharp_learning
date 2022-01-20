using System;

namespace ATM
{
    //AtmMachine - Context class that can have a number of internal states
    public class AtmMachine : IAtmState
    {
        public IAtmState AtmMachineState { get; set; }

        public AtmMachine()
        {
            AtmMachineState = new DebitCardNotInsertedState();
        }

        public string InsertDebitCard()
        {
            var res = AtmMachineState.InsertDebitCard();

            // Debit Card has been inserted so internal state of ATM Machine
            // has been changed to 'DebitCardNotInsertedState'

            if (AtmMachineState is DebitCardNotInsertedState)
            {
                AtmMachineState = new DebitCardInsertedState();
                return "ATM Machine internal state has been moved to: " + AtmMachineState.GetType().Name;
            }

            return res;
        }

        public string EjectDebitCard()
        {
            var res = AtmMachineState.EjectDebitCard();

            // Debit Card has been ejected so internal state of ATM Machine
            // has been changed to 'DebitCardNotInsertedState'

            if (AtmMachineState is DebitCardInsertedState)
            {
                AtmMachineState = new DebitCardNotInsertedState();
                return "ATM Machine internal state has been moved to: " + AtmMachineState.GetType().Name;
            }

            return res;
        }

        public string EnterPin() => AtmMachineState.EnterPin();

        public string WithdrawMoney() => AtmMachineState.WithdrawMoney();
    }
}