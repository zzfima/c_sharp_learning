using ConsoleLoggerService;
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

            ConsoleLogger consoleLogger = new ConsoleLogger();
            consoleLogger.Log("Xopa");
            Console.ReadLine();
        }
    }
}
