namespace CastleWindsorAbstractFactory.Validators
{
    public class CommonCountryAddressValidator : IAddressValidator
    {
        public bool Validate(string strForValidate) => true;
    }
}