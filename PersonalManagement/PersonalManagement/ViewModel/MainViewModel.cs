using Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Models;
using Prism.Commands;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace PersonalManagement.ViewModel
{
    public class MainViewModel
    {
        private ObservableCollection<PersonExport> _personsList;
        private PersonExport _selectedPerson;
        private PersonExport _newPerson;

        private ExportViewModel _exportViewModel;
        private ServiceProvider _serviceProvider;

        public MainViewModel(ServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;

            IEnumerable<Person> personsList = _serviceProvider.GetService<IRepository<Person>>().ReadAll();
            Persons = new ObservableCollection<PersonExport>();
            foreach (Person p in personsList)
                Persons.Add(new PersonExport { Person = p, IsExport = false });

            SelectedPerson = _personsList[0];
            NewPerson = new PersonExport { Person = new Person { DateOfBirth = System.DateTime.Today }, IsExport = false };

            VeiwModelExport = new ExportViewModel(_serviceProvider, Persons);

            EditCommand = new DelegateCommand(EditAction);
            AddCommand = new DelegateCommand(AddAction);
            DeleteCommand = new DelegateCommand(DeleteAction);
        }

        public ExportViewModel VeiwModelExport
        {
            get { return _exportViewModel; }
            set { _exportViewModel = value; }
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

        public DelegateCommand EditCommand { get; private set; }
        public DelegateCommand AddCommand { get; private set; }
        public DelegateCommand DeleteCommand { get; private set; }

        public void EditAction()
        {
            Person person = new Person()
            {
                FirstName = SelectedPerson.Person.FirstName,
                LastName = SelectedPerson.Person.LastName,
                DateOfBirth = SelectedPerson.Person.DateOfBirth,
                Gender = SelectedPerson.Person.Gender
            };

            _serviceProvider.GetService<IRepository<Person>>().Add(person);
            Persons.Add(new PersonExport { Person = person, IsExport = false });
        }

        public void AddAction()
        {
            Person newPerson = new Person()
            {
                FirstName = NewPerson.Person.FirstName,
                LastName = NewPerson.Person.LastName,
                DateOfBirth = NewPerson.Person.DateOfBirth,
                Gender = NewPerson.Person.Gender
            };

            _serviceProvider.GetService<IRepository<Person>>().Add(newPerson);
            Persons.Add(new PersonExport { Person = newPerson, IsExport = false });
        }

        public void DeleteAction()
        {
            PersonExport personExportToDelete = _selectedPerson;
            _serviceProvider.GetService<IRepository<Person>>().Remove(personExportToDelete.Person);
            Persons.Remove(personExportToDelete);
        }
    }
}