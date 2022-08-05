using System.Data;

namespace Backend.DataAccessLibrary.UnitOfWork;

public class UnitOfWork<TEntity> : IUnitOfWork<TEntity>, IDisposable where TEntity : class
{
    private readonly IDbTransaction _dbTransaction;
    public UnitOfWork(IDbTransaction dbTransaction)
    {
        _dbTransaction = dbTransaction;
    }
    
    public IGenericRepository<TEntity> _GenericRepository => new GenericRepository<TEntity>(_dbTransaction);

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