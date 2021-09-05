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
        VMMainView _vMPerson;
        ServiceProvider _serviceProvider;

        public MainWindow()
        {
            InitializeComponent();
            Bootstrap bootstrap = new Bootstrap();
            _serviceProvider = bootstrap.Build();
            _vMPerson = new VMMainView(_serviceProvider);
            this.DataContext = _vMPerson;
        }
    }
}