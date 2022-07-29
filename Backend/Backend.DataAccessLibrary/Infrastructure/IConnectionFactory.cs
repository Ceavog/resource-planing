using System.Data;

namespace Backend.DataAccessLibrary
{
    public interface IConnectionFactory
    {
        public IDbConnection GetConnection { get; }
    }
}