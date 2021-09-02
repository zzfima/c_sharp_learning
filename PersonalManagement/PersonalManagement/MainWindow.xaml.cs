using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

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
            string personsXml = System.IO.File.ReadAllText("PersonsData.xml");
            List<Person> pustomerList = (from e in XDocument.Parse(personsXml).Root.Elements("person")
                                         select new Person
                                         {
                                             FirstName = (string)e.Element("FirstName"),
                                             LastName = (string)e.Element("LastName"),
                                             DateOfBirth = (DateTime)e.Element("DateOfBirth"),
                                             Gender = (Gender)Enum.Parse(typeof(Gender), (string)e.Element("Gender"))
                                         }).ToList();


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
