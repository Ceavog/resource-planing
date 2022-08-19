using Backend.DataAccessLibrary;
using Backend.Services.Interface;

namespace Backend.Services.Services;

public class OrderPositionsService : IOrderPositionsService
{
    public IEnumerable<OrderPosition> GetAllOrderPositionsByOrderId()
    {
        return null;
    }
}