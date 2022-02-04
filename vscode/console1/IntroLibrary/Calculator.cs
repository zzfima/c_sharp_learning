using Serilog;

namespace IntroLibrary
{
    public class Calculator
    {
        public int Add(int a, int b)
        {
            Log.Logger = new LoggerConfiguration().Enrich.FromLogContext().WriteTo.Console().WriteTo.File("myLog.log").CreateLogger();
            Log.Information("Adding operation");
            Log.Information("Adding {a} and {b}", a, b);
            Log.CloseAndFlush();

            return a + b;
        }
    }
}