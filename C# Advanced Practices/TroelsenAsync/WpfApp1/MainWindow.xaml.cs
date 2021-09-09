using System;
using System.Runtime.Remoting.Messaging;
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
                    //txt.Text = binaryOp.EndInvoke(cb).ToString();
                    BinaryOp bo = (cb as AsyncResult).AsyncDelegate as BinaryOp;
                    txt.Text = bo.EndInvoke(cb).ToString();
                });
            }, null);

            txt.Text = "Call calc";
        }

        static int Add(int x, int y)
        {
            Console.WriteLine($"Add() invoked on thread {Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(3000);
            return x + y + DateTime.Now.Millisecond;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            txt1.Text = DateTime.Now.Millisecond.ToString();
        }
    }
}
