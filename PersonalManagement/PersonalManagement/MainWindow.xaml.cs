using Microsoft.Extensions.DependencyInjection;
using PersonalManagement.ViewModel;
using System.Windows;

namespace PersonalManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Bootstrap bootstrap = new Bootstrap();
            ServiceProvider serviceProvider = bootstrap.Build();
            MainViewModel mainViewModel = new MainViewModel(serviceProvider);
            this.DataContext = mainViewModel;
        }
    }
}