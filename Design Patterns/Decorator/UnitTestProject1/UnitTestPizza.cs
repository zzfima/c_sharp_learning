using Decorator.Pizza;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTestPizza
    {
        [TestMethod]
        public void TestMethodPizza()
        {
            Pizza pizza = new Pizza();
            Assert.AreEqual(pizza.Cost(), 50);
        }

        [TestMethod]
        public void TestMethodExtraCheesePizza()
        {
            Pizza pizza = new Pizza();
            pizza = new ExtraCheesePizza(pizza);
            Assert.AreEqual(pizza.Cost(), 60);
        }

        [TestMethod]
        public void TestMethodExtraExtraExtraCheesePizza()
        {
            Pizza pizza = new Pizza();
            pizza = new ExtraCheesePizza(pizza);
            pizza = new ExtraCheesePizza(pizza);
            pizza = new ExtraCheesePizza(pizza);
            Assert.AreEqual(pizza.Cost(), 80);
        }
    }
}
