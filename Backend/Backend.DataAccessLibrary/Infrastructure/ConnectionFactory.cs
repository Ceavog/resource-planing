using System.Data;
using System.Configuration;
namespace Backend.DataAccessLibrary;


public class ConnectionFactory : IConnectionFactory
{
    private readonly string connectionString = string.Empty;
    public IDbConnection Connection => throw new NotImplementedException();

    public string GetConnectionString(string connectionStringKey)
    {
        var x =  ConfigurationManager.AppSettings["countoffiles"];
        return x;
    }
}