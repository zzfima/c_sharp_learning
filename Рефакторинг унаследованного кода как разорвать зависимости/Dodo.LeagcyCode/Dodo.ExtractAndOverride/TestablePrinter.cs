using System.Collections.Generic;

namespace Dodo.ExtractAndOverride
{
    public class TestablePrinter : Printer
    {
        public TerminalFake TerminalFake { get; private set; }
        public List<string> TextToPrint { get; private set; }

        public TestablePrinter()
        {
            TextToPrint = new List<string>();
        }

        protected override void WriteLine(string line)
        {
            TextToPrint.Add(line);
        }

        protected override Terminal CreateTerminal()
        {
            TerminalFake = new TerminalFake();
            return TerminalFake;
        }
    }
}
