using Implementations;
using Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Models;
using System;

namespace PersonalManagement
{
    public class Bootstrap
    {
        public ServiceProvider Build()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<IRepository<Person>>(new ProductXMLRepository(Properties.Settings.Default.pathToXML));
            services.AddSingleton<IPDFExporter>(new PDFExporter());

            string dirPath = @"Exports\";

            if (!System.IO.Directory.Exists(dirPath))
                System.IO.Directory.CreateDirectory(dirPath);

            services.AddTransient<ITextSharpExporter>(x => ActivatorUtilities.CreateInstance<TextSharpPDFExporter>(x, dirPath + DateTime.Now.Ticks.ToString() + "_" + Properties.Settings.Default.pathToPDF));

            return services.BuildServiceProvider();
        }
    }
}
