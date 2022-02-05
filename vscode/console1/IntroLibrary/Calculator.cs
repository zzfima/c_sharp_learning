using Serilog;

namespace IntroLibrary
{
    public class Calculator
    {
        public int Add(int a, int b)
        {
            Log.Logger = new LoggerConfiguration()
                        .WriteTo.Console()
                        .WriteTo.File("myLog.log")
                        .WriteTo.File("myLog2.log", rollingInterval: RollingInterval.Minute)
                        .CreateLogger();
            Log.Warning("Adding operation");
            Log.Information("Adding {a} and {b}", a, b);
            if (a + b > 50)
            {
                Log.Error("Result is greater than 50");
            }
        
            Log.CloseAndFlush();
            return a + b;
        }
    }
}