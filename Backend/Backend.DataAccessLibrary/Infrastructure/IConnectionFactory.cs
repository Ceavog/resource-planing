using System.Data;

namespace Backend.DataAccessLibrary
{
    public interface IConnectionFactory
    {
        public string GetConnectionString(string connectionStringKey);
        public IDbConnection Connection { get; }
    }
}