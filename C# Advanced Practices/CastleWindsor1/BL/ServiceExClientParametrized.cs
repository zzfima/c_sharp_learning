using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace BL
{
    public class ServiceExClientParametrized
    {
        public IService Service { get; }

        public ServiceExClientParametrized(string serviceName)
        {
            var container = new WindsorContainer();

            //Register IService with a specific implementation and supply its dependencies
            container.Register(Component.For<IService>()
                .ImplementedBy<ServiceEx>()
                .DependsOn(Dependency.OnValue("serviceName", serviceName)));

            Service = container.Resolve<IService>();
        }
    }
}