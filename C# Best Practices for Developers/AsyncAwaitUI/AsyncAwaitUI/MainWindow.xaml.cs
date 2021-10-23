using System;
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
            Console.WriteLine($"1. Thread id {Thread.CurrentThread.ManagedThreadId}");

            await Task.Run(() =>
            {
                Console.WriteLine($"2. Thread id {Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(5000);
                vM.Counter = 0;
            });

            Console.WriteLine($"3. Thread id {Thread.CurrentThread.ManagedThreadId}");
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
