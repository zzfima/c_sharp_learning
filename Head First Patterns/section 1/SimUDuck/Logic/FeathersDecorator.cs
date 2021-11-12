namespace Logic
{
    public abstract class FeathersDecorator
    {
        protected Duck _duck;

        public abstract string DisplayFeathers();

        public FeathersDecorator(Duck duck)
        {
            _duck = duck;
        }
    }
}
