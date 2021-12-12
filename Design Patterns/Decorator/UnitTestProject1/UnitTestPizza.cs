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
            Assert.AreEqual(pizza.Cost(), 60);
        }

        [TestMethod]
        public void TestMethodExtraExtraExtraCheesePizza()
        {
            Pizza pizza = new BasicPizza(); //50
            pizza = new ExtraCheesePizza(pizza); //10
            pizza = new ExtraPapperonyPizza(pizza); //17
            Assert.AreEqual(pizza.Cost(), 77);
        }
    }
}
