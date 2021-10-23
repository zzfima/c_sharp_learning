using System;
using System.Collections;
using System.IO;
using System.Xml.Serialization;

namespace SerializeDeserialize
{
    internal class Program
    {
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

        }
    }

    abstract class PersonAbstract { }
    sealed class PersonSealed { }
    interface IPerson { }
    static class PersonStatic { }
}
