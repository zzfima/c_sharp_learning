namespace ReSharperTipsTricks
{
    public class MyClass
    {
        private readonly int _v;

        public MyClass(int v)
        {
            this._v = v;
            MyVal = v;
        }

        public int MyVal { get; set; }

        public int Vl { get; set; }
        
        public int MyMethod()
        {
            return _v;
        }
    }
}