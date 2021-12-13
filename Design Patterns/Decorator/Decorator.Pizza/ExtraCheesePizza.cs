namespace Decorator.Pizza
{
    public class ExtraCheesePizza : Pizza
    {
        private readonly Pizza _pizza;

        public ExtraCheesePizza(Pizza pizza)
        {
            _pizza = pizza;
        }

        public override int Cost()
        {
            return _pizza.Cost() + 10;
        }
    }
}