namespace IntroLibrary
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Calculator calc = new Calculator();
            Random rnd = new Random();
            int a = rnd.Next(0, 100);
            int b = rnd.Next(0, 100);
            System.Console.WriteLine(calc.Add(a, b));
        }
    }
}