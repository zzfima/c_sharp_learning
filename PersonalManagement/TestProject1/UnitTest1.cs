using Implementations;
using Models;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TestProject1
{
    public class Tests
    {
        string _pathSource = "../../../../PersonalManagement/bin/Debug/net5.0-windows/PersonsData.xml";

        ProductXMLRepository _repository;
        Person _testPeson1;
        Person _testPeson2;

        [SetUp]
        public void Setup()
        {
            File.Copy(_pathSource, "TempPersonsData.xml");
            _repository = new ProductXMLRepository("TempPersonsData.xml");

            _testPeson1 = new Person
            {
                DateOfBirth = new System.DateTime(2000, 1, 02),
                FirstName = "Aaaf0f0ghjdghdf&^%&^%&^",
                LastName = "Bjkhdf&^*&^HSHD%^bb",
                Gender = Gender.Unknown
            };

            _testPeson2 = new Person
            {
                DateOfBirth = new System.DateTime(2010, 3, 02),
                FirstName = "jshdjkh&jhjklhfdsjh&^%&^%&^",
                LastName = "&*^&IHG&^U",
                Gender = Gender.Unknown
            };
        }

        [TearDown]
        public void TearDown()
        {
            File.Delete("TempPersonsData.xml");
        }

        [Test]
        public void TestAll()
        {
            //Read all and check person1 not here
            IEnumerable<Person> allPersons = _repository.ReadAll();
            int cnt = (from p in allPersons where p.Equals(_testPeson1) select p).Count();
            Assert.IsTrue(cnt == 0);

            //Add person1
            _repository.Add(_testPeson1);

            //Read all and check person1 here
            allPersons = _repository.ReadAll();
            cnt = (from p in allPersons where p.Equals(_testPeson1) select p).Count();
            Assert.IsTrue(cnt == 1);

            //Change person1 to person2
            _repository.Update(_testPeson1, _testPeson2);

            //Read all and check person2 here
            allPersons = _repository.ReadAll();
            cnt = (from p in allPersons where p.Equals(_testPeson2) select p).Count();
            Assert.IsTrue(cnt == 1);

            //check person1 not here
            cnt = (from p in allPersons where p.Equals(_testPeson1) select p).Count();
            Assert.IsTrue(cnt == 0);

            //remove person2
            _repository.Remove(_testPeson2);

            ///Read all and check person2 not here
            allPersons = _repository.ReadAll();
            cnt = (from p in allPersons where p.Equals(_testPeson2) select p).Count();
            Assert.IsTrue(cnt == 0);
        }
    }
}