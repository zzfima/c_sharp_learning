using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IronPython.Hosting;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var py = Python.CreateEngine();
            py.Execute("print('Oppa')");

            py.ExecuteFile(@"..\..\some_python.py");

            Console.ReadLine();
        }
    }
}
