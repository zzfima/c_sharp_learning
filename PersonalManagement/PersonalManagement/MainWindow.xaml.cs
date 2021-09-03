using Implementations;
using Interfaces;
using iText.Kernel.Colors;
using Microsoft.Extensions.DependencyInjection;
using Models;
using PersonalManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;

namespace PersonalManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        VMPerson _vMPerson;
        ServiceProvider _serviceProvider;
        public MainWindow()
        {
            InitializeComponent();

            Bootstrap();

            IEnumerable<Person> personsList = _serviceProvider.GetService<IRepository<Person>>().ReadAll();
            _vMPerson = new VMPerson(personsList);
            this.DataContext = _vMPerson;
        }

        private void Bootstrap()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<IRepository<Person>>(new ProductXMLRepository(Properties.Settings.Default.pathToXML));
            services.AddTransient<ITextSharpExporter>(
                x => ActivatorUtilities.CreateInstance<TextSharpPDFExporter>(x, DateTime.Now.Ticks.ToString() + "_" + Properties.Settings.Default.pathToPDF));

            _serviceProvider = services.BuildServiceProvider();
        }

        private void Changed(object sender, NotifyCollectionChangedEventArgs e)
        {
            //_repository.Update(this.dgContent.SelectedItem as Person, this.dgContent.SelectedItem as Person);

        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Person person = new Person()
            {
                FirstName = _vMPerson.SelectedPerson.Person.FirstName,
                LastName = _vMPerson.SelectedPerson.Person.LastName,
                DateOfBirth = _vMPerson.SelectedPerson.Person.DateOfBirth,
                Gender = _vMPerson.SelectedPerson.Person.Gender
            };

            _serviceProvider.GetService<IRepository<Person>>().Add(person);
            _vMPerson.Persons.Add(new PersonExport { Person = person, IsExport = false });
        }

        /// <summary>
        /// Add new Person
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Person newPerson = new Person()
            {
                FirstName = _vMPerson.NewPerson.Person.FirstName,
                LastName = _vMPerson.NewPerson.Person.LastName,
                DateOfBirth = _vMPerson.NewPerson.Person.DateOfBirth,
                Gender = _vMPerson.NewPerson.Person.Gender
            };

            _serviceProvider.GetService<IRepository<Person>>().Add(newPerson);
            _vMPerson.Persons.Add(new PersonExport { Person = newPerson, IsExport = false });
        }

        /// <summary>
        /// Delete Person
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            PersonExport personExportToDelete = _vMPerson.SelectedPerson;
            _serviceProvider.GetService<IRepository<Person>>().Remove(personExportToDelete.Person);
            _vMPerson.Persons.Remove(personExportToDelete);
        }

        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
            using (ITextSharpExporter exporter = _serviceProvider.GetService<ITextSharpExporter>())
            {
                List<PersonExport> personsToExport = (from p in _vMPerson.Persons
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