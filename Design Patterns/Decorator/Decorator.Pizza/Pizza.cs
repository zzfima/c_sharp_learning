namespace Decorator.Pizza
{
    public abstract class Pizza : IPizza
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
}