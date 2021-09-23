using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Transportation;

namespace UnitTestProject1
{
    [TestClass]
    public class FakeItEasyTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var distributor = A.Fake<Distributor>();
            var car = A.Fake<Car>(x => x.WithArgumentsForConstructor(() => new Car("WB 82112")));
            var petrolStation = A.Fake<PetrolStation>();
            var transaction = A.Fake<Transaction>();
            var vehicle = A.Fake<IVehicle>();

            decimal totalPrice = transaction.GetFuelTotalPrice(distributor, 4);

            A.CallTo(() => distributor.GetFuelPrice()).MustHaveHappenedOnceExactly();
            A.CallTo(() => transaction.Finish()).DoesNothing();

            A.CallTo(() => vehicle.CheckEngineStatus()).Throws<NotImplementedException>();

            try
            {
                vehicle.CheckEngineStatus();
            }
            catch (Exception ex)
            {
                var exceptionType = ex.GetType();
                Assert.AreEqual(exceptionType, typeof(NotImplementedException));
            }
        }

        [TestInitialize]
        public void TestInitialize()
        {
            var distributor = A.Fake<Distributor>();
            var car = A.Fake<Car>(x => x.WithArgumentsForConstructor(() => new Car("WB 82112")));
            var petrolStation = A.Fake<PetrolStation>();
            var transaction = A.Fake<Transaction>();
            var vehicle = A.Fake<IVehicle>();
        }
    }
}
