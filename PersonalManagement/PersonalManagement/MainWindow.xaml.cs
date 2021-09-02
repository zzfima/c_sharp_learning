using Implementations;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace PersonalManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Person> myObjects;
        public MainWindow()
        {
            InitializeComponent();

            IRepository<Person> repository = new ProductXMLRepository("PersonsData.xml");
            IEnumerable<Person> pustomerList = repository.ReadAll();
            myObjects = new ObservableCollection<Person>(pustomerList);
            this.dgContent.ItemsSource = myObjects;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            DateTime dt;
            DateTime.TryParse(this.txtDateOfBirth.Text, out dt);

            Gender gender = (Gender)Enum.Parse(typeof(Gender), this.txtGender.Text);

            Person myObject = new Person()
            {
                FirstName = this.txtFirstName.Text,
                LastName = this.txtLastName.Text,
                DateOfBirth = dt,
                Gender = gender
            };
            myObjects.Add(myObject);
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            myObjects.Remove(this.dgContent.SelectedItem as Person);
        }
    }
}
