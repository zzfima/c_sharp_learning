using Interfaces;
using iText.Kernel.Colors;
using Microsoft.Extensions.DependencyInjection;
using Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Implementations
{
    public class PDFExporter : IPDFExporter<PersonExport>
    {
        private ServiceProvider _serviceProvider;
        private ObservableCollection<PersonExport> _persons;

        public PDFExporter(ServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void Export(ObservableCollection<PersonExport> persons)
        {
            using (ITextSharpExporter exporter = _serviceProvider.GetService<ITextSharpExporter>())
            {
                List<PersonExport> personsToExport = (from p in persons
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
        }
    }
}
