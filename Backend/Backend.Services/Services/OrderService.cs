using Backend.DataAccessLibrary;
using Backend.Services.Interface;
using Shared.Models;

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