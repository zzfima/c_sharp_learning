using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace BL
{
    public class ServiceClient
    {
        public IService Service { get; }

        public ServiceClient()
        {
            var container = new WindsorContainer(); // create instance of the container
            container.Register(Component.For<IService>().ImplementedBy<Service>()); // register dependency
            Service = container.Resolve<IService>(); // resolve with Resolve method
        }
    }
}