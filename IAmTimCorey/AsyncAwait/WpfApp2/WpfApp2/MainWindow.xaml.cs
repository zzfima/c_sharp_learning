using System;
using System.Diagnostics;
using System.Threading;
using System.Windows;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ResultsWindow.Text = String.Empty;
        }

        private void ButtonBase_OnClick_Sync(object sender, RoutedEventArgs e)
        {
            ResultsWindow.Text = String.Empty;
            Stopwatch stopwatch = Stopwatch.StartNew();
            for (int i = 0; i < 5; i++)
            {
                LongWork();
                ProgressBar.Value = i * 25;
            }
            stopwatch.Stop();
            long elapsedMs = stopwatch.ElapsedMilliseconds;
            ResultsWindow.Text += $"Total execution time: { elapsedMs }";
        }

        private void ButtonBase_OnClick_Async(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonBase_OnClick_Parallel(object sender, RoutedEventArgs e)
        {

        }

        private void LongWork()
        {
            Thread.Sleep(1000);
            ResultsWindow.Text += "working... \n";
        }
    }
}
