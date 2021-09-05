using Interfaces;
using iText.Kernel.Colors;
using Microsoft.Extensions.DependencyInjection;
using Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace PersonalManagement.ViewModel
{
    public class ExportViewModel
    {
        private ServiceProvider _serviceProvider;
        private ICommand _exportCommand;
        private ObservableCollection<PersonExport> _persons;

        public ExportViewModel(ServiceProvider serviceProvider, ObservableCollection<PersonExport> persons)
        {
            _serviceProvider = serviceProvider;
            _persons = persons;
        }

        public ICommand ExportCommand
        {
            get
            {
                return _exportCommand ?? (_exportCommand = new CommandHandler(
                    () => ExporAction(), true));
            }
        }
        public void ExporAction()
        {
            using (ITextSharpExporter exporter = _serviceProvider.GetService<ITextSharpExporter>())
            {
                List<PersonExport> personsToExport = (from p in _persons
                                                      where p.IsExport
                                                      select p).ToList();

                exporter.AddHeader("Persons List", iText.Layout.Properties.TextAlignment.CENTER, 80);
                exporter.AddHorizontalLineSeparator();

                string[] header = { "FirstName", "LastName", "DateOfBirth", "Gender" };
                string[,] body = new string[personsToExport.Count, 4];
                int rowCnt = 0;

                foreach (PersonExport personExport in personsToExport)
                {
                    body[rowCnt, 0] = personExport.Person.FirstName;
                    body[rowCnt, 1] = personExport.Person.LastName;
                    body[rowCnt, 2] = personExport.Person.DateOfBirth.ToShortDateString();
                    body[rowCnt, 3] = personExport.Person.Gender.ToString();

                    rowCnt++;
                }

                exporter.AddTable(4, true,
                    ColorConstants.LIGHT_GRAY, iText.Layout.Properties.TextAlignment.CENTER, header,
                    ColorConstants.ORANGE, iText.Layout.Properties.TextAlignment.LEFT, body);

                exporter.AddHorizontalLineSeparator();
            }

            MessageBox.Show("Export File created", "Export", MessageBoxButton.OK);
        }
    }
}