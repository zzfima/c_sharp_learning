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
        MainViewModel _mainViewModel;
        ServiceProvider _serviceProvider;

        public MainWindow()
        {
            InitializeComponent();
            Bootstrap bootstrap = new Bootstrap();
            _serviceProvider = bootstrap.Build();
            _mainViewModel = new MainViewModel(_serviceProvider);
            this.DataContext = _mainViewModel;
        }
    }
}