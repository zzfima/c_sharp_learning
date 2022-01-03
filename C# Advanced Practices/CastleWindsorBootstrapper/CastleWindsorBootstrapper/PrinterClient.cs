using System;

namespace CastleWindsorBootstrapper
{
    public class PrinterClient
    {
        private readonly IPrinter _printer;

        public PrinterClient(IPrinter printer)
        {
            _printer = printer;
        }

        public void Do()
        {
            Console.WriteLine(_printer.GetSpecifications());
        }
    }
}