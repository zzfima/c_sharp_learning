using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick_Sync(object sender, RoutedEventArgs e)
        {
            resultsWindow.Text = String.Empty;
            var watch = Stopwatch.StartNew();

            RunDownloadSync();

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;

            resultsWindow.Text += $"Total execution time: { elapsedMs }";
        }

        private async void ButtonBase_OnClick_Async(object sender, RoutedEventArgs e)
        {
            resultsWindow.Text = String.Empty;
            var watch = Stopwatch.StartNew();

            await Task.Run(RunDownloadSync);

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;

            resultsWindow.Text += $"Total execution time: { elapsedMs }";
        }

        private async void ButtonBase_OnClick_Parallel(object sender, RoutedEventArgs e)
        {
            resultsWindow.Text = String.Empty;
            var watch = Stopwatch.StartNew();

            await RunDownloadParallel();

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;

            resultsWindow.Text += $"Total execution time: { elapsedMs }";
        }

        private void RunDownloadSync()
        {
            for (int i = 0; i < 5; i++)
            {
                TimeConsumptionOperation();
            }
        }

        private async Task RunDownloadParallel()
        {
            List<Task> tasks = new List<Task>();

            for (int i = 0; i < 5; i++)
            {
                tasks.Add(Task.Run(TimeConsumptionOperation));
            }

            await Task.WhenAll(tasks);
        }

        private void TimeConsumptionOperation()
        {
            Thread.Sleep(1000);

            resultsWindow.Dispatcher.Invoke(() => resultsWindow.Text += "work... \n");
        }
    }
}
