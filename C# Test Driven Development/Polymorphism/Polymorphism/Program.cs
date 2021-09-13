using System.Collections.Generic;

namespace Polymorphism
{
    public class Program
    {

        private static void Main(string[] args)
        {
            const int hours = 55, wage = 70;
            List<Employee> employees = GetEmployees();

            foreach (var e in employees)
            {
                e.CalculateWeeklySalary(hours, wage);
            }
        }

        private static List<Employee> GetEmployees()
        {
            var someEmployee = new Employee();
            var someContractor = new Contractor();
            var everyone = new List<Employee> { someEmployee, someContractor };
            return everyone;
        }
    }
}