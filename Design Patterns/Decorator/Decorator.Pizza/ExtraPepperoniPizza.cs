namespace Decorator.Pizza
{
    public class ExtraPepperoniPizza : Pizza
    {
        private readonly Pizza _pizza;

        public ExtraPepperoniPizza(Pizza pizza)
        {
            _pizza = pizza;
        }

        public override int Cost()
        {
            return _pizza.Cost() + 17;
        }
    }
}