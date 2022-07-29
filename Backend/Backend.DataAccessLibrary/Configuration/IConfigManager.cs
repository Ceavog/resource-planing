using Microsoft.Extensions.Configuration;

namespace Backend.DataAccessLibrary.Configuration
{
    public interface IConfigManager
    {
        string Sample_Database { get; set; }
    }
}
