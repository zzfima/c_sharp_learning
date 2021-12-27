using System;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadVSThredPool
{
    public class Worker
    {
        public void StartWorkByThread(string payload)
        {
            Console.WriteLine("Start StartWorkByThread");
            var workingThread = new Thread(() => Work(payload));
            workingThread.Start();
            Console.WriteLine(workingThread.Join(1000));
            Console.WriteLine("Finish StartWorkByThread");
        }

        public void StartWorkByTask(string payload)
        {
            var workingTask = new Task(() => Work(payload));

            workingTask.ContinueWith(t =>
            {
                Console.WriteLine("Error");
            }, TaskContinuationOptions.OnlyOnFaulted);

            workingTask.ContinueWith(t =>
            {
                Console.WriteLine("Good");
            }, TaskContinuationOptions.OnlyOnRanToCompletion);

            workingTask.Start();

            Task.WaitAll(new Task[] { workingTask }, 1000);
        }

        private void Work(object payload)
        {
            int i = 0;
            Console.WriteLine(payload);
            Thread.Sleep(2000);
            //Console.WriteLine(555 / i);
        }
    }
}