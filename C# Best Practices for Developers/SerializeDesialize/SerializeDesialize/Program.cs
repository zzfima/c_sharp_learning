using System.IO;
using System.Xml.Serialization;

namespace SerializeDesialize
{
    internal class Program
    {
        static void Main(string[] args)
        {
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
        }
    }
}
