using System;

namespace Polymorphism
{
    public class Contractor : Employee
    {
        public override string CalculateWeeklySalary(int weeklyHours, int wage)
        {
            var salary = weeklyHours * wage;
            string result = $"This HAPPY CONTRACTOR worked {weeklyHours} hrs. Paid for {weeklyHours} hrs at $ {wage} hr = ${salary}";
            Console.WriteLine("\n" + result + "\n");
            return result;
        }
    }
}