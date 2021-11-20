using ConsoleLoggerService;

namespace NugetClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleLogger consoleLogger = new ConsoleLogger();
            consoleLogger.Log("Hello");
        }
    }
}
