using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadVSThredPool
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