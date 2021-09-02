﻿using Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Implementations
{
    public class ProductXMLRepository : IRepository<Person>
    {
        private string _pathToXML;
        public ProductXMLRepository(string pathToXML)
        {
            _pathToXML = pathToXML;
        }

        public void Add(Person entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Person> ReadAll()
        {
            string personsXml = System.IO.File.ReadAllText(_pathToXML);
            IEnumerable<Person> pustomerList = (from e in XDocument.Parse(personsXml).Root.Elements("person")
                                                select new Person
                                                {
                                                    FirstName = (string)e.Element("FirstName"),
                                                    LastName = (string)e.Element("LastName"),
                                                    DateOfBirth = (DateTime)e.Element("DateOfBirth"),
                                                    Gender = (Gender)Enum.Parse(typeof(Gender), (string)e.Element("Gender"))
                                                }).ToList();
            return pustomerList;
        }

        public void Remove(Person entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Person entity)
        {
            throw new NotImplementedException();
        }
    }
}