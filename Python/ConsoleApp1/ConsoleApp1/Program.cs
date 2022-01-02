using IronPython.Hosting;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var engine = Python.CreateEngine();

            //run script
            engine.Execute("print('Oppa')");

            //run simple file
            engine.ExecuteFile(@"..\..\no_func.py");

            var scope = engine.CreateScope();

            //run function without params no returns
            engine.ExecuteFile(@"..\..\funcs.py", scope);
            var func_without_params_no_return = scope.GetVariable("func_without_params_no_return");
            func_without_params_no_return();

            //run function without params returns string
            engine.ExecuteFile(@"..\..\funcs.py", scope);
            var func_without_params_return_string = scope.GetVariable("func_without_params_return_string");
            string res = func_without_params_return_string();
            Console.WriteLine(res);

            //run function with params returns int
            engine.ExecuteFile(@"..\..\funcs.py", scope);
            var func_with_params_return_int = scope.GetVariable("func_with_params_return_int");
            int r = func_with_params_return_int(66, 77);
            Console.WriteLine(r);

            Console.ReadLine();
        }
    }
}