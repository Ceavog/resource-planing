using Backend.DataAccessLibrary;
using Backend.DataAccessLibrary.UnitOfWork;
using Backend.Services.Interface;

namespace Backend.Services.Services;

public class OrderTypesService : IOrderTypesService
{
    private readonly IUnitOfWork _unitOfWork;
    public OrderTypesService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public void AddType(OrderType orderType)
    {
        
         _unitOfWork._OrderTypeRepository.Add(orderType);
         // _unitOfWork.Rollback();
         // _unitOfWork.Commit();
         // _unitOfWork.Dispose();
    }
}