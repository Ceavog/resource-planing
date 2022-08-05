using Backend.DataAccessLibrary;
using Backend.DataAccessLibrary.UnitOfWork;
using Backend.Services.Interface;

namespace Backend.Services.Services;

public class OrderTypesService : IOrderTypesService
{
    private readonly IUnitOfWork<OrderType> _unitOfWork;
    public OrderTypesService(IUnitOfWork<OrderType> unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public void AddType(OrderType orderType)
    {
        
         _unitOfWork._GenericRepository.Add(orderType);
         // _unitOfWork.Rollback();
         // _unitOfWork.Commit();
         // _unitOfWork.Dispose();
    }
}