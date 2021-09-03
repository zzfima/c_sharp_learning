using Implementations;
using Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Globalization;
using System.Windows;

namespace PersonalManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Person> _persons;
        ServiceProvider _serviceProvider;
        public MainWindow()
        {
            InitializeComponent();

            Bootstrap();

            IEnumerable<Person> pustomerList = _serviceProvider.GetService<IRepository<Person>>().ReadAll();
            _persons = new ObservableCollection<Person>(pustomerList);
            this.dgContent.ItemsSource = _persons;
            _persons.CollectionChanged += Changed;
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
            Gender gender = (Gender)Enum.Parse(typeof(Gender), this.txtGender.Text);

            Person myObject = new Person()
            {
                FirstName = this.txtFirstName.Text,
                LastName = this.txtLastName.Text,
                DateOfBirth = this.dateOfBirth.DisplayDate,
                Gender = gender
            };

            _serviceProvider.GetService<IRepository<Person>>().Add(myObject);
            _persons.Add(myObject);
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            _serviceProvider.GetService<IRepository<Person>>().Remove(this.dgContent.SelectedItem as Person);
            _persons.Remove(this.dgContent.SelectedItem as Person);
        }

        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
