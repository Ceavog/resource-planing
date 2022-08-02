using Dapper;

namespace Backend.DataAccessLibrary;

public class OrderTypesRepository : GenericRepository<OrderTypes>, IOrderTypesRepository
{
    private readonly IConnectionFactory _connectionFactory;
    public OrderTypesRepository(IConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }
    public async Task AddTest()
    {
        var query = @"insert into et_database.OrderTypes(Id, TypeName) values (5,'sdasda')";
        var x = _connectionFactory.GetConnection;
        SqlMapper.Execute(_connectionFactory.GetConnection, query);
    }
}