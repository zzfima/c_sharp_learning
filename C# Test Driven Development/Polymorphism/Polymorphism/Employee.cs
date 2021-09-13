using System;

namespace Polymorphism
{
    public class Employee
    {
        public virtual string CalculateWeeklySalary(int weeklyHours, int wage)
        {
            var salary = 40 * wage;
            string result = $"This ANGRY EMPLOYEE worked {weeklyHours} hrs. Paid for 40 hrs at $ {wage} hr = ${salary}";
            Console.WriteLine("\n" + result + "\n");
            return result;
        }
    }
}