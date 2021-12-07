using System;

namespace MockProject
{
    public class MyClass
    {
        SomeClass someClass;

        public MyClass(SomeClass someClass)
        {
            this.someClass = someClass;
        }

        public void MyMethod(string method)
        {
            method = "test";
            someClass.DoSomething();
        }
    }

    public class SomeClass
    {
        public void DoSomething()
        {
            Console.WriteLine();
        }
    }
}