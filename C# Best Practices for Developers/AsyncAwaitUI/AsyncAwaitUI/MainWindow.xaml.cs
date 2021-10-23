using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace AsyncAwaitUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        VM vM = new VM();

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = vM;
        }

        private async void Button_Click1(object sender, RoutedEventArgs e)
        {
            await Task.Run(() =>
            {
                Thread.Sleep(2000);
                vM.Counter = 0;
            });
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            NewMethod();
        }

        private void NewMethod()
        {
            vM.Counter++;
        }
    }
}
