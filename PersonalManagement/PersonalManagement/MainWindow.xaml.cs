using Implementations;
using Interfaces;
using iText.Kernel.Colors;
using Microsoft.Extensions.DependencyInjection;
using Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        ObservableCollection<PersonExport> _personExportObservable;
        ServiceProvider _serviceProvider;
        public MainWindow()
        {
            InitializeComponent();

            Bootstrap();

            IEnumerable<Person> personsList = _serviceProvider.GetService<IRepository<Person>>().ReadAll();
            _personExportObservable = new ObservableCollection<PersonExport>();
            foreach (Person p in personsList)
                _personExportObservable.Add(new PersonExport { Person = p, IsExport = false });
            this.dgContent.ItemsSource = _personExportObservable;
            _personExportObservable.CollectionChanged += Changed;
        }

        private void Bootstrap()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<IRepository<Person>>(new ProductXMLRepository(Properties.Settings.Default.pathToXML));
            services.AddTransient<ITextSharpExporter, TextSharpPDFExporter>();

            services.AddTransient<ITextSharpExporter>(
                x => ActivatorUtilities.CreateInstance<TextSharpPDFExporter>(x, Properties.Settings.Default.pathToPDF));

            _serviceProvider = services.BuildServiceProvider();
        }

        private void Changed(object sender, NotifyCollectionChangedEventArgs e)
        {
            //_repository.Update(this.dgContent.SelectedItem as Person, this.dgContent.SelectedItem as Person);

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Gender gender = (Gender)this.comboBoxGender.SelectedItem;

            Person person = new Person()
            {
                FirstName = this.txtFirstName.Text,
                LastName = this.txtLastName.Text,
                DateOfBirth = this.dateOfBirth.DisplayDate,
                Gender = gender
            };

            _serviceProvider.GetService<IRepository<Person>>().Add(person);
            _personExportObservable.Add(new PersonExport { Person = person, IsExport = false });
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            PersonExport personExportToDelete = this.dgContent.SelectedItem as PersonExport;
            _serviceProvider.GetService<IRepository<Person>>().Remove(personExportToDelete.Person);
            _personExportObservable.Remove(this.dgContent.SelectedItem as PersonExport);
        }

        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
            using (ITextSharpExporter exporter = _serviceProvider.GetService<ITextSharpExporter>())
            {
                List<PersonExport> personsToExport = (from p in this._personExportObservable
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
        }

    }
}
