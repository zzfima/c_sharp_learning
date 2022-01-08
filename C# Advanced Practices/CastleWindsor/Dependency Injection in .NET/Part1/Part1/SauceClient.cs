using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Configuration.Interpreters;

namespace Part1
{
    public class SauceClient
    {
        private readonly WindsorContainer _container;

        public IIngredient GetIngredientIsraeli() => _container.Resolve<IIngredient>("Israeli");
        public IIngredient GetIngredientBearnaise() => _container.Resolve<IIngredient>("Bearnaise");
        public IIngredient GetIngredientDefault() => _container.Resolve<IIngredient>();

        public SauceClient(bool readConfigurationFromFile = false)
        {
            if (readConfigurationFromFile)
            {
                var interpreter = new XmlInterpreter(@"CastleConfiguration.config");
                _container = new WindsorContainer(interpreter);
            }
            else
            {
                _container = new WindsorContainer();
                _container.Register(
                    Component
                        .For<IIngredient>()
                        .ImplementedBy<SauceBearnaise>().Named("Bearnaise"), //First is a default
                    Component
                        .For<IIngredient>()
                        .ImplementedBy<IsraeliSauce>().Named("Israeli"));
            }
        }
    }
}