using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace BL
{
    public class ServiceExClient
    {
        public IService Service { get; }

        public ServiceExClient()
        {
            var container = new WindsorContainer();

            //Register IService with a specific implementation and supply its dependencies
            container.Register(Component.For<IService>()
                .ImplementedBy<ServiceEx>()
                .DependsOn(Dependency.OnValue("serviceName", "ServiceEX")));

            Service = container.Resolve<IService>();
        }
    }
}