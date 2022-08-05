using System.Data;
using Dapper.Contrib.Extensions;

namespace Backend.DataAccessLibrary;


public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{
    private readonly IDbTransaction _dbTransaction;
    public GenericRepository(IDbTransaction dbTransaction)
    {
        _dbTransaction = dbTransaction;
    }
    public void Add(TEntity entity)
    {
        _dbTransaction.Connection.Insert<TEntity>(entity, _dbTransaction);
    }

    public void Delete(TEntity entity)
    {
        _dbTransaction.Connection.Delete<TEntity>(entity);
    }

    public TEntity Get(int Id)
    {
        return _dbTransaction.Connection.Get<TEntity>(Id);
    }

    public IEnumerable<TEntity> GetAll()
    {
        return _dbTransaction.Connection.GetAll<TEntity>().ToList();
    }

    public void Update(TEntity entity)
    {
        _dbTransaction.Connection.Update<TEntity>(entity);
    }
}