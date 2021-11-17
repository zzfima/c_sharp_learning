using MessagePrinter;
using System;

namespace SimpleDependency
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var s = new MessagePrintingService();
            s.PrintMessage();
            Console.ReadLine();
        }
    }
}
