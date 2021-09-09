using System;
using System.Threading;
using System.Windows;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public delegate int BinaryOp(int x, int y);
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BinaryOp binaryOp = Add;

            IAsyncResult asyncResult = binaryOp.BeginInvoke(2, 5, (cb) =>
            {
                Dispatcher.Invoke(() =>
                {
                    txt.Text = "Finished";
                });
            }, null);
            txt.Text = "Call calc";
            //txt.Text = binaryOp.EndInvoke(asyncResult).ToString();
        }

        static int Add(int x, int y)
        {
            Console.WriteLine($"Add() invoked on thread {Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(3000);
            return x + y;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            txt1.Text = DateTime.Now.Millisecond.ToString();
        }
    }
}
