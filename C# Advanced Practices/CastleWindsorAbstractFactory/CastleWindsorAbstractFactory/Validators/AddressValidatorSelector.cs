using System.Reflection;
using Castle.Facilities.TypedFactory;

namespace CastleWindsorAbstractFactory.Validators
{
    public class AddressValidatorSelector : DefaultTypedFactoryComponentSelector
    {
        public AddressValidatorSelector() : base(fallbackToResolveByTypeIfNameNotFound: true) { }

        protected override string GetComponentName(MethodInfo method, object[] arguments)
        {
            return base.GetComponentName(method, arguments);
        }
    }
}