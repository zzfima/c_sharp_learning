using System;

namespace Transportation
{
    public class Car : IVehicle
    {
        private string _plateNumber;
        public string PlateNumber => _plateNumber;

        public Car(string plateNumber)
        {
            _plateNumber = plateNumber;
        }

        public void CheckEngineStatus()
        {
            Console.WriteLine("Engine OK");
        }

        public void OpenFuelTank()
        {
            Console.WriteLine("Fuel tank opened");
        }
    }
}
