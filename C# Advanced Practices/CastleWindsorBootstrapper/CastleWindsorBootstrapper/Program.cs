using WindsorExtensions.SafeTypedFactory;

namespace CastleWindsorBootstrapper
{
    class Program
    {
        static void Main(string[] args)
        {
            var printerClient = new Castle.Windsor.WindsorContainer();
            var printer = printerClient.Resolve<IPrinter>();
        }
    }
}
