using System.Data;
using MySql.Data.MySqlClient;

namespace Backend.DataAccessLibrary;


public class ConnectionFactory : IConnectionFactory
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
            //connection.ConnectionString = _connectionStrings.Sample_Database;
            var connection = new MySqlConnection(); 
            connection.ConnectionString = "Server=localhost; Port=6603; Database=et_database; Uid=root; Pwd=pieczywo;";
            connection.Open();
            return connection;
        }
    }
}