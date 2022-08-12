using System.Data;

namespace Backend.DataAccessLibrary.UnitOfWork;

public class UnitOfWork: IUnitOfWork, IDisposable
{
    private readonly IConnectionFactory _connectionFactory;
    private readonly IDbTransaction _dbTransaction;
    public UnitOfWork(IConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
        _dbTransaction = _connectionFactory.GetConnection.BeginTransaction();
    }

    public IGenericRepository<Category> _CategoryRepository => new GenericRepository<Category>(_dbTransaction);
    public IGenericRepository<Client> _ClientRepository => new GenericRepository<Client>(_dbTransaction);
    public IGenericRepository<Delivery> _DeliveryRepository => new GenericRepository<Delivery>(_dbTransaction);
    public IGenericRepository<Employee> _EmployeeRepository => new GenericRepository<Employee>(_dbTransaction);
    public IGenericRepository<MenuPosition> _MenuPositionRepository =>
        new GenericRepository<MenuPosition>(_dbTransaction);
    public IGenericRepository<Order> _OrderRepository => new GenericRepository<Order>(_dbTransaction);
    public IGenericRepository<OrderPosition> _OrderPositionRepository =>
        new GenericRepository<OrderPosition>(_dbTransaction);
    public IGenericRepository<OrderType> _OrderTypeRepository => new GenericRepository<OrderType>(_dbTransaction);
    public void Rollback()
    {
        _dbTransaction.Rollback();
    }
    public void Commit()
    {
        try
        {
            _dbTransaction.Commit();
        }
        catch (Exception e)
        {
            _dbTransaction.Rollback();   
        }
    }
    public void Dispose()
    {
        _dbTransaction.Connection?.Close();
        _dbTransaction.Connection?.Dispose();
        _dbTransaction.Dispose();
    }
}