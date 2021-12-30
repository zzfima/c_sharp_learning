namespace ThreadVSThredPool
{
    public class ConcreteMixer
    {
        private readonly double _concreteAmount;
        private readonly double _waterAmount;
        public double ConcreteAmount => _concreteAmount;
        public double WaterAmount => _waterAmount;

        public ConcreteMixer(double concreteAmount, double waterAmount)
        {
            _waterAmount = waterAmount;
            _concreteAmount = concreteAmount;
        }

        public override string ToString()
        {
            return $"{nameof(ConcreteAmount)}: {ConcreteAmount}, {nameof(WaterAmount)}: {WaterAmount}";
        }

        protected bool Equals(ConcreteMixer other)
        {
            return _concreteAmount.Equals(other._concreteAmount) && _waterAmount.Equals(other._waterAmount);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((ConcreteMixer) obj);
        }
    }
}