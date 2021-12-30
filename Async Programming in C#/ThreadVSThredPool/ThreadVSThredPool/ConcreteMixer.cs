namespace ThreadVSThreadPool
{
    public class ConcreteMixer
    {
        public double ConcreteAmount { get; }
        public double WaterAmount { get; }

        public ConcreteMixer(double concreteAmount, double waterAmount)
        {
            WaterAmount = waterAmount;
            ConcreteAmount = concreteAmount;
        }

        public override string ToString()
        {
            return $"{nameof(ConcreteAmount)}: {ConcreteAmount}, {nameof(WaterAmount)}: {WaterAmount}";
        }

        private bool Equals(ConcreteMixer other)
        {
            return ConcreteAmount.Equals(other.ConcreteAmount) && WaterAmount.Equals(other.WaterAmount);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((ConcreteMixer) obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}