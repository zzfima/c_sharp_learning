using StockAnalyzer.Core;
using StockAnalyzer.Core.Domain;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Navigation;

namespace StockAnalyzer.Windows
{
    public partial class MainWindow : Window
    {
        private static string API_URL = "https://ps-async.fekberg.com/api/stocks";
        private Stopwatch stopwatch = new Stopwatch();

        public MainWindow()
        {
            InitializeComponent();
        }


        private async void Search_Click(object sender, RoutedEventArgs e)
        {
            BeforeLoadingStockData();

            /*
            using (var client = new HttpClient())
            {
                var responseTask = client.GetAsync($"{API_URL}/{StockIdentifier.Text}");
                var response = await responseTask;
                var contentTask = response.Content.ReadAsStringAsync();
                var content = await contentTask;
                await Task.Delay(1000);
                var data = JsonConvert.DeserializeObject<IEnumerable<StockPrice>>(content);
                Stocks.ItemsSource = data;
            }
            */

            try
            {
                //bad model: cross thread etc
                /*
                new System.Threading.Thread(() =>
                {
                    var store = new DataStore();
                    var stockPricesTask = store.GetStockPrices(StockIdentifier.Text);
                    var stockPrices = stockPricesTask.Result;
                    Stocks.ItemsSource = stockPrices;
                }).Start();
                */

                //good model
                var store = new DataStore();
                var stockPricesTask = store.GetStockPrices(StockIdentifier.Text);
                var stockPrices = await stockPricesTask;
                Stocks.ItemsSource = stockPrices;
            }
            catch (System.Exception ex)
            {
                Notes.Background = System.Windows.Media.Brushes.Red;
                Notes.Text += "\n";
                Notes.Text += ex.Message;
                Notes.Foreground = System.Windows.Media.Brushes.Yellow;
            }

            AfterLoadingStockData();
        }

        private void BeforeLoadingStockData()
        {
            Notes.Background = System.Windows.Media.Brushes.White;
            Notes.Foreground = System.Windows.Media.Brushes.Black;

            stopwatch.Restart();
            StockProgress.Visibility = Visibility.Visible;
            StockProgress.IsIndeterminate = true;
        }

        private void AfterLoadingStockData()
        {
            StocksStatus.Text = $"Loaded stocks for {StockIdentifier.Text} in {stopwatch.ElapsedMilliseconds}ms";
            StockProgress.Visibility = Visibility.Hidden;
        }

        private void Hyperlink_OnRequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));

            e.Handled = true;
        }

        private void Close_OnClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}