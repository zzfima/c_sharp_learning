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
            Pizza pizza = new BasicPizza();
            Assert.AreEqual(pizza.Cost(), 50);
        }

        [TestMethod]
        public void TestMethodExtraCheesePizza()
        {
            Pizza pizza = new BasicPizza();
            pizza = new ExtraCheesePizza(pizza);
            var actual = 60;
            Assert.AreEqual(pizza.Cost(), actual);
        }

        [TestMethod]
        public void TestMethodExtraExtraExtraCheesePizza()
        {
            Pizza pizza = new BasicPizza(); //50
            pizza = new ExtraCheesePizza(pizza); //10
            pizza = new ExtraPepperoniPizza(pizza); //17
            Assert.AreEqual(pizza.Cost(), 77);
        }
    }
}