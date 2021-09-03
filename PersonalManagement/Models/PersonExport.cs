using System;
using System.ComponentModel;

namespace Models
{
    public class PersonExport : INotifyPropertyChanged
    {
        Person person;
        Boolean isExport;

        public Person Person
        {
            get
            {
                return person;
            }
            set
            {
                person = value;
                OnPropertyChanged("Person");
            }
        }

        public Boolean IsExport
        {
            get
            {
                return isExport;
            }
            set
            {
                isExport = value;
                OnPropertyChanged("IsExport");
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
    }
}
