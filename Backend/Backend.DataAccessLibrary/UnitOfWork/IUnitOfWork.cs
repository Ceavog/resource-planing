using System.Data;
using Backend.DataAccessLibrary.Repositories;

namespace Backend.DataAccessLibrary.UnitOfWork;

public interface IUnitOfWork
{
    void Commit();
    void Dispose();
    void Rollback();
    IGenericRepository<Category> _CategoryRepository { get; }
    IGenericRepository<Client> _ClientRepository { get; }
    IGenericRepository<Delivery> _DeliveryRepository { get; }
    IGenericRepository<Employee> _EmployeeRepository { get; }
    IGenericRepository<MenuPosition> _MenuPositionRepository { get; }
    IGenericRepository<Order> _OrderRepository { get; }
    IGenericRepository<OrderPosition> _OrderPositionRepository { get; }
    IGenericRepository<OrderType> _OrderTypeRepository { get; }
    IGenericRepository<User> _UserRepository { get; }
    ICustomRepository _CustomRepository { get; }
}