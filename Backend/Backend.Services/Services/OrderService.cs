using Backend.DataAccessLibrary;
using Backend.DataAccessLibrary.UnitOfWork;
using Backend.Services.Interface;
using Shared.Models;

namespace Backend.Services.Services;

public class OrderService : IOrderService
{
    private readonly IUnitOfWork _UnitOfWork;
    public OrderService(IUnitOfWork unitOfWork)
    {
        _UnitOfWork = unitOfWork;
    }
    public IEnumerable<Order> GetAllOrders()
    {
        return _UnitOfWork._OrderRepository.GetAll();
    }

    public IEnumerable<Order> GetAllOrdersWithOrderPositions()
    {
        var Orders = _UnitOfWork._CustomRepository.GetOrdersWithPositions("true");
        return Orders;
    }
}