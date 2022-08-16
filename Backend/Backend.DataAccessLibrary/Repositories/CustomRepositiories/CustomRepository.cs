using System.Data;
using Backend.DataAccessLibrary.Configuration;
using Dapper;

namespace Backend.DataAccessLibrary.Repositories;

public class CustomRepository : ICustomRepository
{
    private readonly IDbTransaction _dbTransaction;
    private readonly IConfiguration _configuration;
    public CustomRepository(IDbTransaction dbTransaction, IConfiguration configuration)
    {
        _dbTransaction = dbTransaction;
        _configuration = configuration;
    }

    public IEnumerable<Order> GetOrdersWithPositions(string condition)
    {
        var SqlFilePath = Path.Join(_configuration.DataAccessLibraryPath, "/GetAllPositions.sql");
        var sql = File.ReadAllText(SqlFilePath);
        sql = sql.Replace("condition", condition);
        var orders = _dbTransaction.Connection.Query<Order, MenuPosition, Order>(sql,
            (order, menuPosition) =>
            {
                order.MenuPositions = new List<MenuPosition> { menuPosition };
                return order;
            }, splitOn:"MenuPositionId");

        var result = orders.GroupBy(x => x.Id).Select(y =>
        {
            var groupedOrder = y.First();
            groupedOrder.MenuPositions = y.Select(x => x.MenuPositions.Single()).ToList();
            return groupedOrder;
        }).ToList();

        return result;
    }
    
}