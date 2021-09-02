﻿using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace PersonalManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Pesrson> myObjects;
        public MainWindow()
        {
            InitializeComponent();

            myObjects = new ObservableCollection<Pesrson>()
            {
                new Pesrson(){FirstName = "Moshe", LastName = "Cohen", DateOfBirth = new System.DateTime(1977, 11,11), Gender = Gender.Male},
                new Pesrson(){FirstName = "Lea", LastName = "Maman", DateOfBirth = new System.DateTime(1978, 10,10), Gender = Gender.Female},
                new Pesrson(){FirstName = "Avi", LastName = "Abuhzira", DateOfBirth = new System.DateTime(1979, 9,9), Gender = Gender.Male}
            };

            this.dgContent.ItemsSource = myObjects;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            DateTime dt;
            DateTime.TryParse(this.txtDateOfBirth.Text, out dt);

            Gender gender = (Gender)Enum.Parse(typeof(Gender), this.txtGender.Text);

            Pesrson myObject = new Pesrson()
            {
                FirstName = this.txtFirstName.Text,
                LastName = this.txtLastName.Text,
                DateOfBirth = dt,
                Gender = gender
            };
            myObjects.Add(myObject);
        }
    }
}
