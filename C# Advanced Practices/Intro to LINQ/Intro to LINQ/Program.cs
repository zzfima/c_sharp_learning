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

            Console.WriteLine();
            var firstNumbersLessThan6 = numbers.TakeWhile(n => n < 6);
            foreach (var n in firstNumbersLessThan6)
                Console.Write(n + " ");

            Console.WriteLine();
            var wordsA = new string[] { "cherry", "apple", "blueberry" };
            var wordsB = new string[] { "cherry", "apple", "blueberry" };
            Console.WriteLine($"The sequence is match: {wordsA.SequenceEqual(wordsB)}");

            Console.WriteLine();
            int[] vectorA = { 0, 2, 4, 5, 6 };
            int[] vectorB = { 1, 3, 5, 7, 8 };
            var dotProduct = vectorA.Zip(vectorB, (a, b) => a * b);
            foreach (var n in dotProduct)
                Console.Write(n + " ");
            Console.WriteLine();
            Console.WriteLine($"Sum of dotProduct of A and B: {dotProduct.Sum()}");

            Console.WriteLine();
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };
            var pairs = from a in numbersA
                        from b in numbersB
                        where a < b
                        select (a, b);
            foreach (var n in pairs)
                Console.Write(n + " ");

            //Lazy
            Console.WriteLine();
            int i = 0;
            var q = from n in numbers select ++i;
            foreach (var n in q)
                Console.WriteLine($"v={n}, i={i}");

            //Eager
            Console.WriteLine();
            i = 0;
            q = (from n in numbers select ++i).ToList();
            foreach (var n in q)
                Console.WriteLine($"v={n}, i={i}");


        }
    }
}
