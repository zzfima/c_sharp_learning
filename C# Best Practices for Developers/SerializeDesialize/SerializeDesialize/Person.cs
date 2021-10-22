using System.Runtime.Serialization;

namespace SerializeDesialize
{
    public class Person : ISerializable
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {

        }
    }
}
