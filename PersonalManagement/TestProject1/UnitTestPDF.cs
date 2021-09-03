using Implementations;
using Interfaces;
using iText.Kernel.Colors;
using iText.Layout.Properties;
using NUnit.Framework;
using System.IO;

namespace TestProject1
{
    public class UnitTestPDF
    {
        string _pathSource = "testPdfExport.pdf";

        [SetUp]
        public void Setup()
        {

        }

        [TearDown]
        public void TearDown()
        {
            File.Delete(_pathSource);
        }

        [Test]
        public void TestAll()
        {
            using (ITextSharpExporter exporter = new TextSharpPDFExporter(_pathSource))
            {
                exporter.AddHeader("Test", iText.Layout.Properties.TextAlignment.CENTER, 50.5f);
                exporter.AddHorizontalLineSeparator();
                exporter.AddHeader("Sub Test", iText.Layout.Properties.TextAlignment.LEFT, 11.5f);
                exporter.AddImage("download.png");

                string[] headers = { "T", "Y", "E" };
                string[,] body = { { "t1", "y1", "e1" }, { "t2", "y2", "e2" }, { "t3", "y3", "e3" }, { "t4", "y4", "e4" } };

                exporter.AddTable(
                    3, true,
                    ColorConstants.GRAY, TextAlignment.CENTER, headers,
                    ColorConstants.WHITE, TextAlignment.LEFT, body);
            }
        }
    }
}