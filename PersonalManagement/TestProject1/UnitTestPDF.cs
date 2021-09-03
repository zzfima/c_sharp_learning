using Implementations;
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
            using (PDFExporter exporter = new PDFExporter(_pathSource))
            {
                exporter.AddHeader("Test", iText.Layout.Properties.TextAlignment.CENTER, 50.5f);
                exporter.AddHorizontalLineSeparator();
                exporter.AddHeader("Sub Test", iText.Layout.Properties.TextAlignment.LEFT, 11.5f);
                exporter.AddImage("download.png");
            }
        }
    }
}