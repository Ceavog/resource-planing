using Microsoft.Extensions.Configuration;

namespace Backend.DataAccessLibrary.Configuration
{
    public interface IConfiguration
    {
        string Sample_Database { get; set; }
        string DataAccessLibraryPath { get; set; }
    }
}
