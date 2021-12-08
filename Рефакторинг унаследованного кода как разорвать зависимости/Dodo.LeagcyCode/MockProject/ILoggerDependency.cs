using System;
using System.Threading.Tasks;

namespace MockProject
{
    public interface ILoggerDependency 
    { 
        string GetCurrentDirectory(); 
        string GetDirectoryByLoggerName(string loggerName); 
        string DefaultLogger { get; } 
    } 
}