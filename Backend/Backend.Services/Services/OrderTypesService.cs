using Backend.DAL_EF;
using Backend.DataAccessLibrary;
using Backend.Services.Interface;

namespace Backend.Services.Services;

public class OrderTypesService : IOrderTypesService
{
    private readonly ApplicationDbContext _applicationDbContext;
    public OrderTypesService(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }
    public void AddType()
    {
        var type = new OrderType()
        {
            TypeName = "lalalala"
        };
        _applicationDbContext.OrderTypes.Add(type);
        _applicationDbContext.SaveChanges();
    }
}