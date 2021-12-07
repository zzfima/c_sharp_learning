namespace Dodo.ExtractAndOverride
{
    public class TerminalFake : Terminal
    {
        public string Line { get; private set; }

        public override void PrintLine(string message)
        {
            Line = message;
        }
    }
}