using System;

namespace ThreadVSThreadPool
{
    class Program
    {
        static void Main(string[] args)
        {
            Worker worker = new Worker();

            worker.StartWorkByTask("kamfora task");

            Console.ReadLine();
        }
    }
}