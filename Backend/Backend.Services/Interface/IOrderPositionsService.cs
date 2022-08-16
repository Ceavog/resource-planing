using Backend.DataAccessLibrary;

namespace Backend.Services.Interface;

public interface IOrderPositionsService
{
    IEnumerable<OrderPosition> GetAllOrderPositionsByOrderId();
}