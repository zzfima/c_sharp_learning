using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ReadWriteLock
{
    class Program
    {
        private static readonly ReaderWriterLockSlim _lockSlim = new ReaderWriterLockSlim();
        private static readonly Dictionary<int, string> _users = new Dictionary<int, string>();
        private static readonly Random _random = new Random();

        static void Main(string[] args)
        {
            var t1 = Task.Factory.StartNew(Read);
            Task.WaitAll
            (
                Task.Factory.StartNew(Read),
                Task.Factory.StartNew(Read),
                Task.Factory.StartNew(Write, "Sean"),
                Task.Factory.StartNew(Read),
                Task.Factory.StartNew(Write, "Glenn"),
                Task.Factory.StartNew(Write, "Newman")
            );
        }

        static async void Read()
        {
            for (int i = 0; i < 10; i++)
            {
                _lockSlim.EnterReadLock();

                // The read lock is being released without being held.
                //await Task.Delay(50); 

                _lockSlim.ExitReadLock();
            }
        }


        static async void Write(object user)
        {
            for (int i = 0; i < 10; i++)
            {
                _lockSlim.EnterWriteLock();
                var rnd = GetRand();
                Console.WriteLine(user + " added with id " + rnd);
                if (!_users.ContainsKey(rnd))
                    _users.Add(rnd, user.ToString());
                else
                    Console.WriteLine("User already exists");
                //The write lock is being released without being held
                //await Task.Delay(250);
                Thread.Sleep(250);
                _lockSlim.ExitWriteLock();
            }
        }

        private static int GetRand()
        {
            var res = 0;
            lock (_random)
            {
                res = _random.Next(1, 1000);
            }

            return res;
        }
    }
}