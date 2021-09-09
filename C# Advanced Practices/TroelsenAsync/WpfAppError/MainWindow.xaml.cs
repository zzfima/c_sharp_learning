using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace WpfAppError
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
            try
            {
                int res = await binaryOp(2, 5);
                txt.Text = res.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        static async Task<int> Add(int x, int y)
        {
            Console.WriteLine($"Add() invoked on thread {Thread.CurrentThread.ManagedThreadId}");
            await Task.Run(() =>
            {
                Thread.Sleep(3000);
                if (DateTime.Now.Millisecond > 500)
                    throw new Exception("HaraBara");
            });
            return x + y + DateTime.Now.Millisecond;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            txt1.Text = DateTime.Now.Millisecond.ToString();
        }
    }
}
