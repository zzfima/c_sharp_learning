namespace Decorator.Pizza
{
    public abstract class Pizza
    {
        public abstract int Cost();
    }

    public class BasicPizza : Pizza
    {
        public override int Cost()
        {
            return 50;
        }
    }

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

    public class ExtraPapperonyPizza : Pizza
    {
        private readonly Pizza _pizza;

        public ExtraPapperonyPizza(Pizza pizza)
        {
            _pizza = pizza;
        }

        public override int Cost()
        {
            return _pizza.Cost() + 17;
        }
    }
}
