using Implementations;
using Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Models;
using Prism.Commands;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace PersonalManagement.ViewModel
{
    public class ExportViewModel
    {
        private ServiceProvider _serviceProvider;
        private ObservableCollection<PersonExport> _persons;
        private IPDFExporter<PersonExport> _pdfExporter;

        public ExportViewModel(ServiceProvider serviceProvider, ObservableCollection<PersonExport> persons)
        {
            _serviceProvider = serviceProvider;
            _persons = persons;
            _pdfExporter = new PDFExporter(_serviceProvider);
            ExportCommand = new DelegateCommand(() =>
            {
                _pdfExporter.Export(_persons);
                MessageBox.Show("Export File created", "Export", MessageBoxButton.OK);
            });
        }

        public DelegateCommand ExportCommand { get; private set; }
    }
}