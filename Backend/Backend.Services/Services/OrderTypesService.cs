using Backend.DataAccessLibrary;
using Backend.Services.Interface;

namespace Backend.Services.Services;

public class OrderTypesService : IOrderTypesService
{
    private readonly IGenericRepository<OrderType> _genericRepository;
    public OrderTypesService(IGenericRepository<OrderType> genericRepository)
    {
        _genericRepository = genericRepository;
    }

    public IEnumerable<OrderType> GetAllOrderTypes()
    {
        return _genericRepository.GetAll();
    }
}