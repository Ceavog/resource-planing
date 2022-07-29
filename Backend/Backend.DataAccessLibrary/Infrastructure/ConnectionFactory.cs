using System.Data;
using System.Configuration;
using Backend.DataAccessLibrary.Configuration;
using System.Data.Common;
using Microsoft.Extensions.Configuration;

namespace Backend.DataAccessLibrary;


public class ConnectionFactory : IConnectionFactory
{
    private readonly IConfigManager configManager;
    public ConnectionFactory(IConfigManager configManager)
    {
        this.configManager = configManager;
    }

     public IDbConnection GetConnection
    {
        get
        {
            var factory = DbProviderFactories.GetFactory("System.Data.SqlClient");
            var connection = factory.CreateConnection();
            connection.ConnectionString = configManager.Sample_Database;
            connection.Open();
            return connection;
        }
    }
}