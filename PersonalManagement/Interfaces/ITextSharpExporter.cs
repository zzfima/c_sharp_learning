using iText.Kernel.Colors;
using iText.Layout.Properties;
using System;

namespace Interfaces
{
    /// <summary>
    /// Export  
    /// </summary>
    public interface ITextSharpExporter : IDisposable
    {
        /// <summary>
        /// Add document header
        /// </summary>
        /// <param name="headerText"></param>
        /// <param name="textAlignment"></param>
        /// <param name="fontSize"></param>
        void AddHeader(string headerText, TextAlignment textAlignment, float fontSize);

        void AddHorizontalLineSeparator();
        void AddImage(string imagePath);

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
        void AddTable(int numColumns, bool largeTable, 
            Color tableHeadersBackgroundColor, TextAlignment tableHeadersTextAlignment, string[] tableHeadersText, 
            Color tableBodyBackgroundColor, TextAlignment tableBodyTextAlignment, string[,] tableBodyText);
    }
}
