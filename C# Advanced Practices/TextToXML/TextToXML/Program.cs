using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TextToXML
{
    class Program
    {
        static String m_defaultConfig = "<?xml version=\"1.0\" encoding=\"utf-8\" ?><DiagUIExtensionsConfiguration><VendorDiagnosticsApplications xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">" +
                                "<ApplicationHostingInformation ApplicationName=\"K3Util\" MenuOptionName=\"K3 Utility\" DeviceType=\"Robots\" RelevantEFEMTypes=\"kawasaki\" ExecutableName=\"notepad.exe\" ExecutableLocations=\"C:\\windows\\system32;C:\\test\" CommandLineArgs=\"\" ShouldStopMHService=\"true\"/>" +
                                "<ApplicationHostingInformation ApplicationName=\"Sinfonia\" MenuOptionName=\"Shinko Utility\" DeviceType=\"Loaders\" RelevantEFEMTypes=\"Shinko\" ExecutableName=\"Diagnostics.Configuration.exe\" ExecutableLocations=\"C:\\windows\\system32;C:\\Program Files\\KLA-Tencor\\Component Suite\\bin\" CommandLineArgs=\"\" ShouldStopMHService=\"false\"/>" +
                                "</VendorDiagnosticsApplications><PhoenixApplications xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">" +
                                "<PhoenixApplicationHostingInformation ApplicationName=\"WTA\" MenuOptionName=\"Wafer Transfer\" ExecutableName=\"WaferTransfer.exe\" ExecutableLocations=\"C:\\Program Files\\KLA-Tencor\\ASD Phoenix\\Binaries\" CommandLineArgs=\"\" ShouldStopMHService=\"false\"/>" +
                                "<PhoenixApplicationHostingInformation ApplicationName=\"TP\" MenuOptionName=\"Throughput\" ExecutableName=\"Throughput.exe\" ExecutableLocations=\"C:\\Program Files\\KLA-Tencor\\ASD Phoenix\\Binaries\" CommandLineArgs=\"\" ShouldStopMHService=\"false\"/>" +
                                "</PhoenixApplications><PhxDiagViewNavigationInformation NavOptionName=\"NavPhoenixDiagnostics\">" +
                                "<LeafNavigationInformation NavOptionName=\"NavHardware\" PageName=\"Hardware Status\" TypeInfo=\"DiagnosticExtensions.HardwareStatus, DiagnosticExtensions\"/>" +
                                "<LeafNavigationInformation NavOptionName=\"NavInterlock\" PageName=\"Interlock Status\" TypeInfo=\"DiagnosticExtensions.InterlockStatus, DiagnosticExtensions\"/></PhxDiagViewNavigationInformation></DiagUIExtensionsConfiguration>";


        static void Main(string[] args)
        {
            string xmlString = System.IO.File.ReadAllText("XMLFile1.xml");
            var res = m_defaultConfig.Equals(xmlString);
            XmlTextReader reader = new XmlTextReader(xmlString, XmlNodeType.Document, null);

        }
    }
}
