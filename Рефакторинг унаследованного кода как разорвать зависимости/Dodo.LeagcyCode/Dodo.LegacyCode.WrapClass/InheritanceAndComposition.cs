using System;

namespace Dodo.LegacyCode.WrapClass
{
    public class Printer
    {
        public virtual void Print(string textToPrint)
        {
            Console.WriteLine($"Printer prints {textToPrint}");
        }
    }

    public class InkPrinter
    {
        private readonly Printer _printer;

        public InkPrinter(Printer printer)
        {
            _printer = printer;
        }
        public void Print(string textToPrint)
        {
            Console.WriteLine("Ink job starts....");
            _printer.Print(textToPrint);
        }
    }

    public class LaserPrinter : Printer
    {
        private readonly Printer _printer;

        public LaserPrinter(Printer printer)
        {
            _printer = printer;
        }

        public override void Print(string textToPrint)
        {
            Console.WriteLine("Laser job starts....");
            _printer.Print(textToPrint);
        }
    }
}
