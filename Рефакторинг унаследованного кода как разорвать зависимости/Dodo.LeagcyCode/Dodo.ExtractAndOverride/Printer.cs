using System;
using System.Collections.Generic;

namespace Dodo.ExtractAndOverride
{
    public class Printer
    {
        public void PrintReceipt(ShoppingCart shoppingCart)
        {
            WriteLine("-----Receipt-------");
            WriteLine("-------------------");

            var terminal = new Terminal();
            terminal.PrintLine("<<Shopping cart items>>");

            WriteLine("-----Total--------");
            WriteLine($"----- {shoppingCart.TotalPrice} ---------");
        }

        protected virtual void WriteLine(string line) => Console.WriteLine(line);
    }

    public class TestablePrinter : Printer
    {
        public List<string> TextToPrint { private set; get; }

        public TestablePrinter()
        {
            TextToPrint = new List<string>();
        }

        protected override void WriteLine(string line)
        {
            TextToPrint.Add(line);
        }
    }
}
