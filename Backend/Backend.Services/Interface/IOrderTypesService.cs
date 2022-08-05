using Backend.DataAccessLibrary;

namespace Backend.Services.Interface;

public interface IOrderTypesService
{
    void AddType(OrderType orderType);
}