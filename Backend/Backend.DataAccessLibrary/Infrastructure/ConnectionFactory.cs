using System.Data;
using MySql.Data.MySqlClient;

namespace Backend.DataAccessLibrary;


public abstract class ConnectionFactory : IConnectionFactory
{
    // todo - make connection factory use connection string form appsettings.json
    // private readonly IConnectionStrings _connectionStrings;
    // public ConnectionFactory(IConnectionStrings connectionStrings)
    // {
    //     this._connectionStrings = connectionStrings;
    // }
    
    
     public IDbConnection GetConnection
    {
        get
        {
            // todo - change to use factory insted of simple connection - whatever does it mean 
            
            // DbProviderFactories.RegisterFactory("System.Data.SqlClient", System.Data.SqlClient.SqlClientFactory.Instance);
            // var factory = DbProviderFactories.GetFactory("System.Data.SqlClient");
            // var connection = factory.CreateConnection();
            
            //connection.ConnectionString = _connectionStrings.Sample_Database;
            //for now its hardcoded because i cant find i way to test this
            // todo -- maybe ask someone more experienced

            var connection = new MySqlConnection(); 
            connection.ConnectionString = "Server=localhost; Port=6603; Database=et_database; Uid=root; Pwd=pieczywo;";
            connection.Open();
            return connection;
        }
    }
}