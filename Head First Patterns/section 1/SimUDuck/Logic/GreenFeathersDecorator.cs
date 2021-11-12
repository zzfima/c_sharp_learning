namespace Logic
{
    public class GreenFeathersDecorator : FeathersDecorator
    {
        private FeathersDecorator _decorator;

        public GreenFeathersDecorator(FeathersDecorator decorator):base(null)
        {
            this._decorator = decorator;
        }
        public override string DisplayFeathers()
        {
            return _decorator.DisplayFeathers() + ", green feathers";
        }
    }
}
