using Interfaces;
using iText.Kernel.Colors;
using Microsoft.Extensions.DependencyInjection;
using Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace PersonalManagement.ViewModel
{
    public class VMMainView
    {
        private ObservableCollection<PersonExport> _personsList;
        private PersonExport _selectedPerson;
        private PersonExport _newPerson;

        private ICommand _editCommand;
        private ICommand _addCommand;
        private ICommand _deleteCommand;
        private ICommand _exportCommand;

        private ServiceProvider _serviceProvider;

        public VMMainView(ServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;

            IEnumerable<Person> personsList = _serviceProvider.GetService<IRepository<Person>>().ReadAll();
            Persons = new ObservableCollection<PersonExport>();
            foreach (Person p in personsList)
                Persons.Add(new PersonExport { Person = p, IsExport = false });

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

        public ICommand EditCommand
        {
            get
            {
                return _editCommand ?? (_editCommand = new CommandHandler(
                    () => EditAction(), true));
            }
        }

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

        public ICommand AddCommad
        {
            get
            {
                return _addCommand ?? (_addCommand = new CommandHandler(
                    () => AddAction(), true));
            }
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

        public ICommand DeleteCommand
        {
            get
            {
                return _deleteCommand ?? (_deleteCommand = new CommandHandler(
                    () => DeleteAction(), true));
            }
        }

        public void DeleteAction()
        {
            PersonExport personExportToDelete = SelectedPerson;
            _serviceProvider.GetService<IRepository<Person>>().Remove(personExportToDelete.Person);
            Persons.Remove(personExportToDelete);
        }

        public ICommand ExportCommand
        {
            get
            {
                return _exportCommand ?? (_exportCommand = new CommandHandler(
                    () => ExporAction(), true));
            }
        }

        public void ExporAction()
        {
            using (ITextSharpExporter exporter = _serviceProvider.GetService<ITextSharpExporter>())
            {
                List<PersonExport> personsToExport = (from p in Persons
                                                      where p.IsExport
                                                      select p).ToList();

                exporter.AddHeader("Persons List", iText.Layout.Properties.TextAlignment.CENTER, 80);
                exporter.AddHorizontalLineSeparator();

                string[] header = { "FirstName", "LastName", "DateOfBirth", "Gender" };
                string[,] body = new string[personsToExport.Count, 4];
                int rowCnt = 0;

                foreach (PersonExport personExport in personsToExport)
                {
                    body[rowCnt, 0] = personExport.Person.FirstName;
                    body[rowCnt, 1] = personExport.Person.LastName;
                    body[rowCnt, 2] = personExport.Person.DateOfBirth.ToShortDateString();
                    body[rowCnt, 3] = personExport.Person.Gender.ToString();

                    rowCnt++;
                }

                exporter.AddTable(4, true,
                    ColorConstants.LIGHT_GRAY, iText.Layout.Properties.TextAlignment.CENTER, header,
                    ColorConstants.ORANGE, iText.Layout.Properties.TextAlignment.LEFT, body);

                exporter.AddHorizontalLineSeparator();
            }

            MessageBox.Show("Export File created", "Export", MessageBoxButton.OK);
        }
    }
}