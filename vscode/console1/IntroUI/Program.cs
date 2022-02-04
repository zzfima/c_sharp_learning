namespace IntroLibrary
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Calculator calc = new Calculator();
            System.Console.WriteLine(calc.Add(1, 2));

            Console.ReadLine();
        }
    }
}