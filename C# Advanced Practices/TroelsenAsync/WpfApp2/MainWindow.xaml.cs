using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public delegate Task<int> BinaryOp(int x, int y);
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            BinaryOp binaryOp = Add;
            int res = await binaryOp(2, 5);
            txt.Text = res.ToString();
        }

        static async Task<int> Add(int x, int y)
        {
            Console.WriteLine($"Add() invoked on thread {Thread.CurrentThread.ManagedThreadId}");
            await Task.Run(() => Thread.Sleep(3000));
            return x + y + DateTime.Now.Millisecond;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            txt1.Text = DateTime.Now.Millisecond.ToString();
        }
    }
}
