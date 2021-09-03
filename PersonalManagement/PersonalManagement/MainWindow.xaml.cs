using Implementations;
using Interfaces;
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
        IRepository<Person> _repository;

        public MainWindow()
        {
            InitializeComponent();

            _repository = new ProductXMLRepository("PersonsData.xml");
            IEnumerable<Person> pustomerList = _repository.ReadAll();
            _persons = new ObservableCollection<Person>(pustomerList);
            this.dgContent.ItemsSource = _persons;
            _persons.CollectionChanged += Changed;
        }

        private void Changed(object sender, NotifyCollectionChangedEventArgs e)
        {
            //_repository.Update(this.dgContent.SelectedItem as Person, this.dgContent.SelectedItem as Person);

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            DateTime dt;
            DateTime.TryParseExact(this.txtDateOfBirth.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt);

            Gender gender = (Gender)Enum.Parse(typeof(Gender), this.txtGender.Text);

            Person myObject = new Person()
            {
                FirstName = this.txtFirstName.Text,
                LastName = this.txtLastName.Text,
                DateOfBirth = dt,
                Gender = gender
            };

            _repository.Add(myObject);
            _persons.Add(myObject);
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            _repository.Remove(this.dgContent.SelectedItem as Person);
            _persons.Remove(this.dgContent.SelectedItem as Person);
        }
    }
}
