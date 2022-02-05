namespace CancellationConsole
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var cts = new CancellationTokenSource();
            var token = cts.Token;
            var task = Task.Run(() =>
            {
                while (!token.IsCancellationRequested)
                {
                    Console.WriteLine("Hello World!");
                    Thread.Sleep(1000);
                }
            }, token);  // pass the token to the task

            Console.WriteLine("Press any key to stop the task");
            Console.ReadLine();
            cts.Cancel();
            Console.ReadLine();
        }
    }
}