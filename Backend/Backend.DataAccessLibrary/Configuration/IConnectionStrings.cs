using Microsoft.Extensions.Configuration;

namespace Backend.DataAccessLibrary.Configuration
{
    public interface IConnectionStrings
    {
        string Sample_Database { get; set; }
    }
}
