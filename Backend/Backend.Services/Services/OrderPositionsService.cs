using Backend.DataAccessLibrary;
using Backend.DataAccessLibrary.UnitOfWork;
using Backend.Services.Interface;

namespace Backend.Services.Services;

public class OrderPositionsService : IOrderPositionsService
{
    private readonly IUnitOfWork _unitOfWork;
    public OrderPositionsService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public IEnumerable<OrderPosition> GetAllOrderPositionsByOrderId()
    {
        return _unitOfWork._OrderPositionRepository.GetAllByCondition("OrderId = 2");
    }
}