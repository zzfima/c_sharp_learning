
using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System;

namespace Implementations
{
    /// <summary>
    /// Export object to PDF file
    /// </summary>
    public class PDFExporter : IDisposable
    {
        private readonly Document _document;
        private bool _disposed = false;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="pdfDocumentPath">Path, where PDF document will be saved</param>
        public PDFExporter(string pdfDocumentPath)
        {
            PdfWriter writer = new PdfWriter(pdfDocumentPath);
            PdfDocument pdf = new PdfDocument(writer);
            _document = new Document(pdf);
        }

        /// <summary>
        /// Add document header
        /// </summary>
        /// <param name="headerText"></param>
        /// <param name="textAlignment"></param>
        /// <param name="fontSize"></param>
        public void AddHeader(string headerText, TextAlignment textAlignment, float fontSize)
        {
            Paragraph header = new Paragraph(headerText)
               .SetTextAlignment(textAlignment)
               .SetFontSize(fontSize);

            _document.Add(header);
        }

        public void AddHorizontalLineSeparator()
        {
            LineSeparator ls = new LineSeparator(new SolidLine());
            _document.Add(ls);
        }

        public void AddImage(string imagePath)
        {
            Image img = new Image(ImageDataFactory
             .Create(imagePath))
             .SetTextAlignment(TextAlignment.CENTER);
            _document.Add(img);
        }

        /// <summary>
        /// Creates table on pdf document includes headers and alues
        /// </summary>
        /// <param name="numColumns"> the number of columns, each column will have equal percent width.</param>
        /// <param name="largeTable">whether parts of the table will be written before all data is added. Note, 
        /// large table does not support auto layout, table width shall not be removed.</param>
        /// <param name="tableHeadersBackgroundColor"></param>
        /// <param name="tableHeadersTextAlignment"></param>
        /// <param name="tableHeadersText"></param>
        /// <param name="tableValuesBackgroundColor"></param>
        /// <param name="tableValuesTextAlignment"></param>
        /// <param name="tableValuesText"></param>
        public void AddTable(
            int numColumns, bool largeTable,
            Color tableHeadersBackgroundColor, TextAlignment tableHeadersTextAlignment, string[] tableHeadersText,
            Color tableBodyBackgroundColor, TextAlignment tableBodyTextAlignment, string[,] tableBodyText)
        {
            Table table = new Table(numColumns, largeTable);

            foreach (string header in tableHeadersText)
            {
                Cell cellHeader = new Cell(1, 1)
                  .SetBackgroundColor(tableHeadersBackgroundColor)
                  .SetTextAlignment(tableHeadersTextAlignment)
                  .Add(new Paragraph(header));
                table.AddCell(cellHeader);
            }

            foreach (string str in tableBodyText)
            {
                Cell cellBody = new Cell(1, 1)
                    .SetBackgroundColor(tableBodyBackgroundColor)
                    .SetTextAlignment(tableBodyTextAlignment)
                    .Add(new Paragraph(str));
                table.AddCell(cellBody);
            }

            _document.Add(table);
        }


        #region Disposing

        ~PDFExporter() => Dispose(false);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                _document.Close();
            }

            //no unmanaged

            _disposed = true;
        }
        #endregion
    }
}
