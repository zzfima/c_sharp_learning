using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace Part1
{
    public class SauceClient
    {
        private readonly WindsorContainer _container;

        public IIngredient GetIngredient() => _container.Resolve<IIngredient>();

        public SauceClient()
        {
            _container = new WindsorContainer();
            _container.Register(Component.For<IIngredient>().ImplementedBy<SauceBearnaise>());
        }
    }
}