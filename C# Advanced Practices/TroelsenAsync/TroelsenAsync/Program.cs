using System;
using System.Threading;

namespace TroelsenAsync
{
    class Program
    {
        public delegate int BinaryOp(int x, int y);
        static void Main(string[] args)
        {
            Console.WriteLine($"Main() invoked on thread {Thread.CurrentThread.ManagedThreadId}");
            BinaryOp binaryOp = Add;
            int res = binaryOp(2, 5);
            Console.WriteLine($"Result of 2+5 is {res}");

            IAsyncResult asyncResult = binaryOp.BeginInvoke(3, 6, (callback) => 
            {
                Console.WriteLine($"Async callback invoked on thread {Thread.CurrentThread.ManagedThreadId}");
            }, null);

            Console.WriteLine($"IAsyncResult IsCompleted: {asyncResult.IsCompleted}");
            Console.WriteLine($"Result is: {binaryOp.EndInvoke(asyncResult)}");

            Console.ReadLine();
        }

        static int Add(int x, int y)
        {
            Console.WriteLine($"Add() invoked on thread {Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(3000);
            return x + y;
        }
    }
}
