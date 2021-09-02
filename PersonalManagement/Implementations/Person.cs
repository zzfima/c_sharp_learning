﻿using System;

namespace Implementations
{
    /// <summary>
    /// Person attributes
    /// Sample POCO object
    /// </summary>
    public class Person
    {
        public Person()
        {

        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
    }
}