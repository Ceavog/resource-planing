using Backend.DataAccessLibrary;
using Shared.Models;

namespace Backend.Services.Interface;

public interface IOrderService
{
    IEnumerable<Order> GetAllOrders();
    IEnumerable<Order> GetAllOrdersWithOrderPositions();
}