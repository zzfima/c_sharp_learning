using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using WindsorExtensions.SafeTypedFactory;

namespace CastleWindsorBootstrapper
{
    public class ControllersInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IPrinter>().ImplementedBy<ColorPrinter>().LifestyleSingleton());
            container.Register(Component.For<IPrinterFactory>().AsFactory());
        }
    }
}
