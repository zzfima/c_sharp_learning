namespace Transportation
{
    public class Distributor
    {
        public virtual decimal GetFuelPrice()
        {
            return 4.50M;
        }

        public void RefuelTheVehicle(IVehicle vehicle)
        {
            vehicle.OpenFuelTank();
        }
    }
}
