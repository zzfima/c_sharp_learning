using System;
using System.Collections.Generic;

namespace Dodo.LegacyCode.WrapClass
{
    public class Employee
    {
        private readonly int _hourlyPayRateUsd;

        public Employee()
        {
            _hourlyPayRateUsd = 35;
        }

        public virtual void Pay(List<TimeEntry> timeEntries, PaymentService paymentService)
        {
            var totalAmount = new Money();
            foreach (var entry in timeEntries)
            {
                var amount = entry.Hours * _hourlyPayRateUsd;
                totalAmount.Add(amount);
            }

            paymentService.Pay(this, totalAmount);
            Console.WriteLine("Employee Pay");
        }
    }
}
