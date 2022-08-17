using System.Data;
using Backend.DataAccessLibrary.Repositories;
using Dapper.Contrib.Extensions;

namespace Backend.DataAccessLibrary;


public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{
    private readonly IDbTransaction _dbTransaction;
    public GenericRepository(IDbTransaction dbTransaction)
    {
        _dbTransaction = dbTransaction;
    }
    public long Add(TEntity entity)
    {
        return _dbTransaction.Connection.Insert<TEntity>(entity, _dbTransaction);
    }

    public void Delete(TEntity entity)
    {
        _dbTransaction.Connection.Delete<TEntity>(entity, _dbTransaction);
    }

    public TEntity Get(int Id)
    {
        return _dbTransaction.Connection.Get<TEntity>(Id, _dbTransaction);
    }

    public IEnumerable<TEntity> GetAll()
    {
        return _dbTransaction.Connection.GetAll<TEntity>(_dbTransaction).ToList();
    }

    public void Update(TEntity entity)
    {
        _dbTransaction.Connection.Update<TEntity>(entity, _dbTransaction);
    }

    public IEnumerable<TEntity> GetAllByCondition(string condition)
    {
       return _dbTransaction.Connection.GetAllByContidion<TEntity>(condition, _dbTransaction);
    }
}