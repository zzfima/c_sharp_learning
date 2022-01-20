using ATM;
using FluentAssertions;
using Xunit;

namespace ATMTests
{
    public class UnitTest1
    {
        [Fact]
        public void TestDebitCardNotInsertedEnterPin()
        {
            var state = new DebitCardNotInsertedState();
            state.EnterPin().Should().Be("You cannot enter the pin, as no Debit Card in ATM Machine slot");
        }

        [Fact]
        public void TestDebitCardInsertedEnterPin()
        {
            var state = new DebitCardInsertedState();
            state.EnterPin().Should().Be("Pin number has been entered correctly");
        }

        [Fact]
        public void TestAtmMachine()
        {
            var atmMachine = new AtmMachine();
            atmMachine.AtmMachineState.GetType().Name.Should().Be("DebitCardNotInsertedState");
            atmMachine.EnterPin().Should().Be("You cannot enter the pin, as no Debit Card in ATM Machine slot");
            atmMachine.WithdrawMoney().Should().Be("You cannot withdraw money, as no Debit Card in ATM Machine slot");
            atmMachine.EjectDebitCard().Should().Be("You cannot eject the Debit Card, as no Debit Card in ATM Machine slot");
            atmMachine.InsertDebitCard().Should().Be("ATM Machine internal state has been moved to: DebitCardInsertedState");
            // Debit Card has been inserted so internal state of ATM Machine has been changed to DebitCardInsertedState
            atmMachine.AtmMachineState.GetType().Name.Should().Be("DebitCardInsertedState");

            atmMachine.EnterPin().Should().Be("Pin number has been entered correctly");
            atmMachine.WithdrawMoney().Should().Be("Money has been withdrawn");
            atmMachine.InsertDebitCard().Should().Be("You cannot insert the Debit Card, as the Debit card is already there");
            atmMachine.EjectDebitCard().Should().Be("ATM Machine internal state has been moved to: DebitCardNotInsertedState");
            // Debit Card has been ejected so internal state of ATM Machine has been changed to DebitCardNotInsertedState
            atmMachine.AtmMachineState.GetType().Name.Should().Be("DebitCardNotInsertedState");
        }
    }
}
