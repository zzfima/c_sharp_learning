using Implementations;
using Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows;

namespace PersonalManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<PersonExport> _personsObservable;
        ServiceProvider _serviceProvider;
        public MainWindow()
        {
            InitializeComponent();

            Bootstrap();

            IEnumerable<Person> personsList = _serviceProvider.GetService<IRepository<Person>>().ReadAll();
            _personsObservable = new ObservableCollection<PersonExport>();
            foreach (Person p in personsList)
                _personsObservable.Add(new PersonExport { Person = p, IsExport = false });
            this.dgContent.ItemsSource = _personsObservable;
            _personsObservable.CollectionChanged += Changed;
        }

        private void Bootstrap()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<IRepository<Person>>(new ProductXMLRepository(Properties.Settings.Default.pathToXML));
            services.AddSingleton<ITextSharpExporter>(new TextSharpPDFExporter(Properties.Settings.Default.pathToPDF));

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
            _personsObservable.Add(new PersonExport { Person = person, IsExport = false });
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            PersonExport personExportToDelete = this.dgContent.SelectedItem as PersonExport;
            _serviceProvider.GetService<IRepository<Person>>().Remove(personExportToDelete.Person);
            _personsObservable.Remove(this.dgContent.SelectedItem as PersonExport);
        }

        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
