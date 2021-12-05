using System;
using System.Collections.Generic;

namespace Dodo.LegacyCode.WrapClass
{
    public class SmsEmployee : Employee
    {
        private readonly Employee _employee;

        public SmsEmployee(Employee employee)
        {
            _employee = employee;
        }

        public override void Pay(List<TimeEntry> timeEntries, PaymentService paymentService)
        {
            _employee.Pay(timeEntries, paymentService);
            Console.WriteLine("SmsEmployee Pay");
        }
    }
}
