namespace Decorator.Pizza
{
    public class Pizza : ICostable
    {
        public virtual int Cost() => 50;
    }

    public class ExtraCheesePizza : ICostable
    {
        private readonly ICostable _costable;

        public ExtraCheesePizza(ICostable costable)
        {
            _costable = costable;
        }

        public int Cost()
        {
            return _costable.Cost() + 10;
        }
    }
}
