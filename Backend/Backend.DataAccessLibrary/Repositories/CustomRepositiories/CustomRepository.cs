using System.Data;
using Dapper;

namespace Backend.DataAccessLibrary.Repositories;

public class CustomRepository : ICustomRepository
{
    private readonly IDbTransaction _dbTransaction;
    public CustomRepository(IDbTransaction dbTransaction)
    {
        _dbTransaction = dbTransaction;
    }

    public IEnumerable<Order> GetOrdersWithPositions(string condition)
    {
       var sql = File.ReadAllText("./CustomSqlQueries/GetAllPositions.sql");
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