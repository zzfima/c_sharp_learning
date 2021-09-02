using System;

namespace PersonalManagement
{
    /// <summary>
    /// Person attributes
    /// Sample POCO object
    /// </summary>
    internal class Pesrson
    {
        public Pesrson()
        {

        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
    }
}