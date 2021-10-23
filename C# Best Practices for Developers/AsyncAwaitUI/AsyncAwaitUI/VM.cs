using System.ComponentModel;
using System.Windows.Media;

namespace AsyncAwaitUI
{
    public class VM : INotifyPropertyChanged
    {
        private int counter;
        private Brush bgColor;

        public int Counter
        {
            get
            {
                return counter;
            }
            set
            {
                counter = value;
                OnPropertyChanged("Counter");

                if (value == 0)
                    BGColor = Brushes.Red;
                else
                    BGColor = Brushes.Green;
            }
        }

        public Brush BGColor
        {
            get
            {
                return bgColor;
            }
            set
            {
                bgColor = value;
                OnPropertyChanged("BGColor");
            }
        }

        public VM()
        {
            Counter = 0;
            BGColor = Brushes.Green;
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
