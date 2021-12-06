using Dodo.ExtractAndOverride;
using NUnit.Framework;
using System.Collections.Generic;

namespace TestProject2
{
    public class WhenPrintReceipt
    {
        [Test]
        public void ShouldPrintFooterLine()
        {
            Printer printer = new Printer();
            printer.PrintReceipt(new ShoppingCart());
            Assert.Pass();
        }

        [Test]
        public void ShouldPrintFooterLineTestable()
        {
            TestablePrinter printer = new TestablePrinter();
            printer.PrintReceipt(new ShoppingCart() { TotalPrice = 60 });
            List<string> textToPrint = new List<string>();
            textToPrint.Add("-----Receipt-------");
            textToPrint.Add("-------------------");
            textToPrint.Add("-----Total--------");
            textToPrint.Add("----- 60 ---------");
            Assert.AreEqual(printer.TextToPrint, textToPrint);
        }
    }
}