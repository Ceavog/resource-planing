using Microsoft.Extensions.Configuration;

namespace Backend.DataAccessLibrary.Configuration
{
    public class Configuration : IConfiguration
    {
        public string Sample_Database { get; set;}
        public string DataAccessLibraryPath { get; set; }
    }
}
