using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace DataLayer
{
    /// <summary>
    /// Person object persistance by XML file
    /// </summary>
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
            XDocument doc = XDocument.Load(_pathToXML);
            IEnumerable<XElement> allPesrons = doc.Descendants("Person");

            allPesrons.Where(node =>
            node.Element("FirstName").Value == entity.FirstName &&
            node.Element("LastName").Value == entity.LastName &&
            node.Element("DateOfBirth").Value == entity.DateOfBirth.ToShortDateString() &&
            node.Element("Gender").Value == entity.Gender.ToString()).Remove();

            doc.Save(_pathToXML);
        }

        public void Update(Person oldEntity, Person newEntity)
        {
            XDocument doc = XDocument.Load(_pathToXML);
            IEnumerable<XElement> allPersons = doc.Descendants("Person");

            IEnumerable<XElement> persosToChange = allPersons.Where(node =>
            node.Element("FirstName").Value == oldEntity.FirstName &&
            node.Element("LastName").Value == oldEntity.LastName &&
            node.Element("DateOfBirth").Value == oldEntity.DateOfBirth.ToShortDateString() &&
            node.Element("Gender").Value == oldEntity.Gender.ToString());

            foreach (XElement node in persosToChange)
            {
                node.Element("FirstName").Value = newEntity.FirstName;
                node.Element("LastName").Value = newEntity.LastName;
                node.Element("DateOfBirth").Value = newEntity.DateOfBirth.ToShortDateString();
                node.Element("Gender").Value = newEntity.Gender.ToString();

            }

            doc.Save(_pathToXML);
        }
    }
}
