using System.Collections.ObjectModel;
using System.Windows;

namespace PersonalManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<MyObject> myObjects;
        public MainWindow()
        {
            InitializeComponent();

            myObjects = new ObservableCollection<MyObject>()
            {
                new MyObject(){C1 = "Jimmy", C2 = "Yang"},
                new MyObject(){C1 = "Marvin", C2 = "Guo"},
                new MyObject(){C1 = "Franklin", C2 = "Chen"}
            };

            this.dgContent.ItemsSource = myObjects;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            MyObject myObject = new MyObject() { C1 = this.txtC1.Text, C2 = this.txtC2.Text };
            myObjects.Add(myObject);
        }
    }
}
