using Moq;
using System.Collections.Generic;

namespace Polymorphism
{
    class Program
    {
        private static void Main(string[] args)
        {
            const int hours = 55, wage = 70;

            var mock = new Mock<Utils>();
            mock.Setup(m => m.GetMockEmployees()).Returns(() => new List<Employee> { new Contractor(), new Employee() });

            List<Employee> employees = mock.Object.GetMockEmployees();

            foreach (var e in employees)
            {
                e.CalculateWeeklySalary(hours, wage);
            }
        }
    }
}
