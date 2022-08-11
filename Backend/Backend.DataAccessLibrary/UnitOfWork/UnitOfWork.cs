using System.Data;

namespace Backend.DataAccessLibrary.UnitOfWork;

public class UnitOfWork: IUnitOfWork, IDisposable
{
    private readonly IDbTransaction _dbTransaction;
    public UnitOfWork(IDbTransaction dbTransaction)
    {
        _dbTransaction = dbTransaction;
    }
    
    public IGenericRepository<Category> _CategoryRepository { get; }
    public IGenericRepository<Client> _ClientRepository { get; }
    public IGenericRepository<Delivery> _DeliveryRepository { get; }
    public IGenericRepository<Employee> _EmployeeRepository { get; }
    public IGenericRepository<MenuPosition> _MenuPositionRepository { get; }
    public IGenericRepository<Order> _OrderRepository { get; }
    public IGenericRepository<OrderPosition> _OrderPositionRepository { get; }
    public IGenericRepository<OrderType> _OrderTypeRepository { get; }
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