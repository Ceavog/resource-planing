using Backend.DataAccessLibrary;

namespace Backend.Services.Interface;

public interface IOrderService
{
    IEnumerable<Order> GetAllOrders();
    IEnumerable<Order> GetAllOrdersWithOrderPositions();
}