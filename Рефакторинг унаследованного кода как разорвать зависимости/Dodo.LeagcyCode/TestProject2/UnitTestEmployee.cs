using Dodo.LegacyCode.WrapClass;
using NUnit.Framework;
using System.Collections.Generic;

namespace TestProject2
{
    public class UnitTestEmployee
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            for (int i = 0; i < 100000; i++)
            {
                Employee employee = new Employee();
                List<TimeEntry> timeEntries = new List<TimeEntry>();

                PaymentService paymentService = new PaymentService();
                employee.Pay(timeEntries, paymentService);

                LoggingEmployee loggingEmployee = new LoggingEmployee(employee);
                loggingEmployee.Pay(timeEntries, paymentService);

                Employee smsEmployee = new SmsEmployee(employee);
                smsEmployee.Pay(timeEntries, paymentService);

                Assert.AreEqual(employee, employee);
            }
        }
    }
}