using System;
using System.Linq;

namespace Intro_to_LINQ
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var lowNums = from n in numbers
                          where n < 5
                          select n;
            foreach (var n in lowNums)
                Console.Write(n + " ");

            Console.WriteLine();
            string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            var shortDigits = digits.Where((digit, index) => digit.Length < index);
            foreach (var n in shortDigits)
                Console.Write(n + " ");

            Console.WriteLine();
            string[] strings = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            var textNums = from n in numbers
                           select strings[n];
            foreach (var n in textNums)
                Console.Write(n + " ");

            Console.WriteLine();
            var first3WACustomers1 = (from c in Customers.CustomerList
                                      where c.Region == "WA"
                                      select c).Take(3);
            foreach (Customer n in first3WACustomers1)
                Console.Write(n.CustomerID + " ");

            Console.WriteLine();
            var first3WACustomers2 = (from c in Customers.CustomerList
                                      from o in c.Orders
                                      where c.Region == "WA"
                                      select (c.CustomerID, o.OrderID, o.OrderDate))
                                      .Take(3);
            foreach (var n in first3WACustomers2)
                Console.Write(n + " ");
        }
    }
}
