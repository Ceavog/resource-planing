using Backend.DataAccessLibrary;

namespace Backend.Services.Interface;

public interface IOrderTypesService
{
    IEnumerable<OrderType> GetAllOrderTypes();
}