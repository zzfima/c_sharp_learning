using System;
using System.ComponentModel;

namespace Models
{
    /// <summary>
    /// Person Model
    /// </summary>
    public class Person : INotifyPropertyChanged
    {
        private string firstName;
        private string lastName;
        private DateTime dateOfBirth;
        private Gender gender;

        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
                OnPropertyChanged("FirstName");
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
                OnPropertyChanged("LastName");
            }
        }

        public DateTime DateOfBirth
        {
            get
            {
                return dateOfBirth;
            }
            set
            {
                dateOfBirth = value;
                OnPropertyChanged("DateOfBirth");
            }
        }
        public Gender Gender
        {
            get
            {
                return gender;
            }
            set
            {
                gender = value;
                OnPropertyChanged("Gender");
            }
        }

        #region INotifyPropertyChanged Members  

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        public override bool Equals(object obj)
        {
            if (!(obj is Person comparedPerson))
                return false;

            return
                FirstName.Equals(comparedPerson.FirstName) &&
                LastName.Equals(comparedPerson.LastName) &&
                DateOfBirth.Equals(comparedPerson.DateOfBirth) &&
                Gender.Equals(comparedPerson.Gender);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(FirstName, LastName, DateOfBirth, Gender);
        }
    }
}