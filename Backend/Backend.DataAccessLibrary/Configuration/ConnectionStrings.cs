using Microsoft.Extensions.Configuration;

namespace Backend.DataAccessLibrary.Configuration
{
    public class ConnectionStrings : IConnectionStrings
    {
        public string Sample_Database { get; set;}
    }
}
