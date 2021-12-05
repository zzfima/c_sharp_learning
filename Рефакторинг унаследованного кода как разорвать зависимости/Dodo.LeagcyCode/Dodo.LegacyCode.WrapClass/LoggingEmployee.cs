using System;
using System.Collections.Generic;

namespace Dodo.LegacyCode.WrapClass
{
    public class LoggingEmployee
    {
        private readonly Employee _employee;

        public LoggingEmployee(Employee employee)
        {
            _employee = employee;
        }

        public void Pay(List<TimeEntry> timeEntries, PaymentService paymentService)
        {
            _employee.Pay(timeEntries, paymentService);

            LogPayment();
        }

        private void LogPayment()
        {
            // logging payment
        }
    }
}
