using Dodo.LegacyCode.WrapClass;
using NUnit.Framework;

namespace TestProject2
{
    public class UnitTestPrinter
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            Printer printer = new Printer();
            PrintText(printer);

            InkPrinter inkPrinter = new InkPrinter(printer);
            inkPrinter.Print("Text");

            printer = new LaserPrinter(printer);
            PrintText(printer);

            Assert.Pass();
        }

        private void PrintText(Printer printer)
        {
            printer.Print($"{printer.GetType().Name} *Text*");
        }
    }
}