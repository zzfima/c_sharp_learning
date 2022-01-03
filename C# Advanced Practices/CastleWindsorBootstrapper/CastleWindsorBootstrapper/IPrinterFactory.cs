using WindsorExtensions.SafeTypedFactory;

namespace CastleWindsorBootstrapper
{
    public interface IPrinterFactory
    {
        IOwner<IPrinter> CreatePrinter();
    }
}