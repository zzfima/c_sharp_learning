using Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PersonalManagement.ViewModel
{
    public class VMPerson
    {
        private ObservableCollection<PersonExport> _personsList;
        private PersonExport _selectedPerson;
        private PersonExport _newPerson;

        public VMPerson(IEnumerable<Person> personsList)
        {
            _personsList = new ObservableCollection<PersonExport>();
            foreach (Person p in personsList)
                _personsList.Add(new PersonExport { Person = p, IsExport = false });

            SelectedPerson = _personsList[0];
            NewPerson = new PersonExport { Person = new Person { DateOfBirth = System.DateTime.Today }, IsExport = false };
        }

        public PersonExport SelectedPerson
        {
            get { return _selectedPerson; }
            set { _selectedPerson = value; }
        }

        public PersonExport NewPerson
        {
            get { return _newPerson; }
            set { _newPerson = value; }
        }

        public ObservableCollection<PersonExport> Persons
        {
            get { return _personsList; }
            set { _personsList = value; }
        }
    }
}