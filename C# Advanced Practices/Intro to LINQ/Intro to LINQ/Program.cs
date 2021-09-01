using System;
using System.Linq;

namespace Intro_to_LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 5, 4, 1, 3, 6, 7, 8, 9 };

            var lowNums = from n in numbers
                          where n < 5
                          select n;

            foreach (int n in lowNums)
                Console.WriteLine(n);
        }
    }
}
