using Backend.DataAccessLibrary;
using Backend.Services.Interface;

namespace Backend.Services.Services;

public class OrderService : IOrderService
{
    public IEnumerable<Order> GetAllOrders()
    {
        return null;
    }

    public IEnumerable<Order> GetAllOrdersWithOrderPositions()
    {
        return null;
    }
}