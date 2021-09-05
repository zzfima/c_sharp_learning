using Implementations;
using Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Models;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace PersonalManagement.ViewModel
{
    public class ExportViewModel
    {
        private ServiceProvider _serviceProvider;
        private ICommand _exportCommand;
        private ObservableCollection<PersonExport> _persons;
        private IPDFExporter<PersonExport> _pdfExporter;

        public ExportViewModel(ServiceProvider serviceProvider, ObservableCollection<PersonExport> persons)
        {
            _serviceProvider = serviceProvider;
            _persons = persons;
            _pdfExporter = new PDFExporter(_serviceProvider);
        }

        public ICommand ExportCommand
        {
            get
            {
                return _exportCommand ?? (_exportCommand = new CommandHandler(
                    () =>
                    {
                        _pdfExporter.Export(_persons);
                        MessageBox.Show("Export File created", "Export", MessageBoxButton.OK);
                    }, true));
            }
        }
    }
}