using System.Data;
using Backend.DataAccessLibrary.Configuration;
using MySql.Data.MySqlClient;

namespace Backend.DataAccessLibrary;


public class ConnectionFactory : IConnectionFactory
{
    //constructor must be commented out for testing
    private readonly IConfiguration _connectionStrings;
    public ConnectionFactory(IConfiguration connectionStrings)
    {
        this._connectionStrings = connectionStrings;
    }
    
     public IDbConnection GetConnection
    {
        get
        {
            
            var connection = new MySqlConnection(); 
            // for testing
            //connection.ConnectionString = "Server=localhost; Port=6603; Database=et_database; Uid=root; Pwd=pieczywo;";
            connection.ConnectionString = _connectionStrings.Sample_Database;
            connection.Open();
            return connection;
        }
    }
}