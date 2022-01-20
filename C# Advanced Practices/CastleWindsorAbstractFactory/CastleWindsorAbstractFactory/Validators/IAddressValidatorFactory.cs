using CastleWindsorAbstractFactory.Validators;

namespace CastleWindsorAbstractFactory
{
    public interface IAddressValidatorFactory
    {
        IAddressValidator GetAddressValidator(Address address);
        void Release(IAddressValidator created);
    }
}
