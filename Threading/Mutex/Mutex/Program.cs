using System;
using System.Runtime.Remoting.Messaging;
using System.Security.AccessControl;

namespace Mutex
{
    class Program
    {
        static readonly System.Threading.Mutex m = new System.Threading.Mutex(false, "M2");

        static void Main(string[] args)
        {
            m.SetAccessControl(new MutexSecurity("M2", AccessControlSections.Access ));
            System.Threading.Mutex.TryOpenExisting("M2", out var m12);
            var ac1 = m.WaitOne();
            System.Threading.Mutex.TryOpenExisting("M2", out var m22);
            System.Threading.Mutex.TryOpenExisting("M2", out var m32);
            Console.ReadLine();
        }
    }
}