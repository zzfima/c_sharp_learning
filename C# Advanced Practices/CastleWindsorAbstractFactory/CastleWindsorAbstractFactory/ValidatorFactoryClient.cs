using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using CastleWindsorAbstractFactory.Validators;

namespace CastleWindsorAbstractFactory
{
    public class ValidatorFactoryClient
    {        
        public WindsorContainer Container { get; set; }

        public ValidatorFactoryClient()
        {
            Container = new WindsorContainer();

            IRegistration[] registrations =
            {
                Component.For<IAddressValidator, UnitedStatesAddressValidator>().Named("AddressValidatorForUSA"),
                Component.For<IAddressValidator, FinlandAddressValidator>().Named("AddressValidatorForFinland"),
                Component.For<IAddressValidator, MalawiAddressValidator>().Named("AddressValidatorForMalawi"),
                Component.For<IAddressValidator, CommonCountryAddressValidator>()
                    .Named("AddressValidatorForCommonCountry")
            };

            Container.Register(registrations);
            Container.AddFacility<TypedFactoryFacility>();
            Container.Register(Component.For<IAddressValidatorFactory>().AsFactory(new AddressValidatorSelector()));
        }
    }
}