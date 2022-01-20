using System;
using ATM;
using FluentAssertions;
using Xunit;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void TestDebitCardNotInsertedEnterPin()
        {
            IAtmState state = new DebitCardNotInsertedState();
            state.EnterPin().Should().Be("You cannot enter the pin, as No Debit Card in ATM Machine slot");
        }

        [Fact]
        public void TestDebitCardInsertedEnterPin()
        {
            IAtmState state = new DebitCardInsertedState();
            state.EnterPin().Should().Be("Pin number has been entered correctly");
        }
    }
}
