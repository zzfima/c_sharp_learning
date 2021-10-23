using System;
using System.Collections;
using System.IO;
using System.Threading;
using System.Xml.Serialization;

namespace SerializeDeserialize
{
    internal class Program
    {
        delegate int MyDelegate();
        static event MyDelegate MyEvent;

        static void Main(string[] args)
        {
            DisposableObject disposableObject = new DisposableObject("manka.txt");

            using (DisposableObject disposableObject2 = new DisposableObject("manka3.txt"))
            {
                String s = disposableObject2.ToString();
            }

            Person person = new Person();
            person.FirstName = "Alex";
            person.LastName = "Smith";
            XmlSerializer serializer = new XmlSerializer(typeof(Person));
            using (Stream stream = new FileStream("xmlFile.xml", FileMode.Create))
            {
                serializer.Serialize(stream, person);
            }

            XmlSerializer serializer1 = new XmlSerializer(typeof(Person));
            using (Stream stream = new FileStream("xmlFile.xml", FileMode.Open))
            {
                Person p = serializer.Deserialize(stream) as Person;
            }

            IList array = new ArrayList();
            array.Add(person);

            int? i = null;

            Console.WriteLine(i ?? 5);

            if (i == null)
                Console.WriteLine(5);
            else
                Console.WriteLine(i);

            object o = i == null ? 5 : i;
            Console.WriteLine(o);
            o = i?.ToString();
            Console.WriteLine(o);

            MyEvent += () =>
            {
                Console.WriteLine("1");
                Console.WriteLine($"Thread id {Thread.CurrentThread.ManagedThreadId} in Event Handler");
                return 567;
            };

            Console.WriteLine($"Thread id {Thread.CurrentThread.ManagedThreadId} in main");

            IAsyncResult result = MyEvent.BeginInvoke((r) =>
            {
                var v = r.AsyncState;
                Console.WriteLine($"Thread id {Thread.CurrentThread.ManagedThreadId} in BeginInvoke");
            }, "FFFF"
            );

            int endInvokeRes = MyEvent.EndInvoke(result);
            Console.WriteLine(endInvokeRes);
        }
    }

    abstract class PersonAbstract { }
    sealed class PersonSealed { }
    interface IPerson { }
    static class PersonStatic { }
}
