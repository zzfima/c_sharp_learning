namespace CastleWindsorAbstractFactory.Validators
{
    public class UnitedStatesAddressValidator : IAddressValidator
    {
        public bool Validate(string strForValidate) => true;
    }
}