using System;

namespace Models
{
    /// <summary>
    /// Person attributes
    /// Sample POCO object
    /// </summary>
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is Person comparedPerson))
                return false;

            return
                FirstName.Equals(comparedPerson.FirstName) &&
                LastName.Equals(comparedPerson.LastName) &&
                DateOfBirth.Equals(comparedPerson.DateOfBirth) &&
                Gender.Equals(comparedPerson.Gender);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(FirstName, LastName, DateOfBirth, Gender);
        }
    }
}