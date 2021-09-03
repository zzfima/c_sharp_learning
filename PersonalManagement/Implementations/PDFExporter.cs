using Interfaces;

using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System;

namespace Implementations
{
    /// <summary>
    /// Export object to PDF file
    /// </summary>
    public class PDFExporter :  IDisposable
    {
        private readonly Document _document;
        private bool _disposed = false;

        public PDFExporter(string pdfDocumentPath)
        {
            PdfWriter writer = new PdfWriter(pdfDocumentPath);
            PdfDocument pdf = new PdfDocument(writer);
            _document = new Document(pdf);
        }

        public void AddHeader(string headerText, TextAlignment textAlignment, float fontSize)
        {
            Paragraph header = new Paragraph(headerText)
               .SetTextAlignment(textAlignment)
               .SetFontSize(fontSize);

            _document.Add(header);
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
