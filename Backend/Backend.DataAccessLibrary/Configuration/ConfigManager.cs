using Microsoft.Extensions.Configuration;

namespace Backend.DataAccessLibrary.Configuration
{
    public class ConfigManager : IConfigManager
    {
        public string Sample_Database { get; set;}
    }
}
