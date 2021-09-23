namespace Transportation
{
    public class Transaction
    {
        private bool _isCompleted;
        public decimal GetFuelTotalPrice(Distributor distributor, int liters)
        {
            return liters * distributor.GetFuelPrice();
        }

        public virtual void Finish()
        {
            _isCompleted = true;
        }
    }
}
