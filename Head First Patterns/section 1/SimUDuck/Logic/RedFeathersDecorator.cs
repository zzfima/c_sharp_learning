namespace Logic
{
    public class RedFeathersDecorator : FeathersDecorator
    {
        private FeathersDecorator _decorator;

        public RedFeathersDecorator(FeathersDecorator decorator)
        {
            this._decorator = decorator;
        }
        public override string DisplayFeathers()
        {
            return _decorator.DisplayFeathers() + ", red feathers";
        }
    }
}
