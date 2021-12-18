namespace ReSharperTipsTricks
{
    public class MyClass
    {
        private int v;

        public MyClass(int v)
        {
            this.v = v;
            myVal = v;
        }

        public int myVal { get; set; }

        public int VL { get; set; }
        
        public int MyMethod()
        {
            return v;
        }
    }
}