using Dodo.LegacyCode.WrapClass;
using NUnit.Framework;
using System.Collections.Generic;

namespace TestProject2
{
    public class Tests1
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            Employee employee = new Employee();
            List<TimeEntry> timeEntries = new List<TimeEntry>();

            PaymentService paymentService = new PaymentService();
            employee.Pay(timeEntries, paymentService);

            LoggingEmployee loggingEmployee = new LoggingEmployee(employee);
            loggingEmployee.Pay(timeEntries, paymentService);

            Employee smsEmployee = new SmsEmployee(employee);
            smsEmployee.Pay(timeEntries, paymentService);

            Assert.Pass();
        }
    }
}