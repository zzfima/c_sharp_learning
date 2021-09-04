using Implementations;
using Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Models;
using PersonalManagement.ViewModel;
using System;
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
            Bootstrap();
            _vMPerson = new VMMainView(_serviceProvider);
            this.DataContext = _vMPerson;
        }

        private void Bootstrap()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<IRepository<Person>>(new ProductXMLRepository(Properties.Settings.Default.pathToXML));
            string dirPath = @"Exports\";

            if (!System.IO.Directory.Exists(dirPath))
                System.IO.Directory.CreateDirectory(dirPath);

            services.AddTransient<ITextSharpExporter>(x => ActivatorUtilities.CreateInstance<TextSharpPDFExporter>(x, dirPath + DateTime.Now.Ticks.ToString() + "_" + Properties.Settings.Default.pathToPDF));

            _serviceProvider = services.BuildServiceProvider();
        }
    }
}