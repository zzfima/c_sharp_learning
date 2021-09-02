using Interfaces;
using Models;
using System;
using System.Collections.Generic;
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
            XDocument doc = XDocument.Load(_pathToXML);
            XElement root = new XElement("Person");
            root.Add(new XElement("FirstName", entity.FirstName));
            root.Add(new XElement("LastName", entity.LastName));
            root.Add(new XElement("DateOfBirth", entity.DateOfBirth.ToShortDateString()));
            root.Add(new XElement("Gender", entity.Gender));
            doc.Element("Persons").Add(root);
            doc.Save(_pathToXML);
        }

        public IEnumerable<Person> ReadAll()
        {
            string personsXml = System.IO.File.ReadAllText(_pathToXML);
            IEnumerable<Person> pustomerList = (from e in XDocument.Parse(personsXml).Root.Elements("Person")
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
