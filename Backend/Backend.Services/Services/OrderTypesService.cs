using Backend.DataAccessLibrary;
using Backend.Services.Interface;

namespace Backend.Services.Services;

public class OrderTypesService : IOrderTypesService
{
    private readonly IGenericRepository<OrderTypes> _genericRepository;
    public OrderTypesService(IGenericRepository<OrderTypes> genericRepository)
    {
        _genericRepository = genericRepository;
    }

    public IEnumerable<OrderTypes> GetAllOrderTypes()
    {
        return _genericRepository.GetAll();
    }
}