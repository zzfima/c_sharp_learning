using System;

namespace Polymorphism
{
    public class Contractor : Employee
    {
        public override string CalculateWeeklySalary(int weeklyHours, int wage)
        {
            var salary = weeklyHours * wage;
            string result = String.Format("This HAPPY CONTRACTOR worked {0} hrs. Paid for {0} hrs at $ {1} hr = ${2}", weeklyHours, wage, salary);
            Console.WriteLine("\n" + result + "\n");
            return result;
        }
    }
}
