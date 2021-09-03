using Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace PersonalManagement.ViewModel
{
    class VMPerson
    {
        private ObservableCollection<PersonExport> _personsList;
        private PersonExport _selectedPerson;

        public VMPerson(IEnumerable<Person> personsList)
        {
            _personsList = new ObservableCollection<PersonExport>();
            foreach (Person p in personsList)
                _personsList.Add(new PersonExport { Person = p, IsExport = false });

            SelectedPerson = _personsList[0];
        }

        public PersonExport SelectedPerson
        {
            get { return _selectedPerson; }
            set { _selectedPerson = value; }
        }

        public ObservableCollection<PersonExport> Persons
        {
            get { return _personsList; }
            set { _personsList = value; }
        }

        private ICommand mUpdater;
        public ICommand UpdateCommand
        {
            get
            {
                if (mUpdater == null)
                    mUpdater = new Updater();
                return mUpdater;
            }
            set
            {
                mUpdater = value;
            }
        }
    }
}