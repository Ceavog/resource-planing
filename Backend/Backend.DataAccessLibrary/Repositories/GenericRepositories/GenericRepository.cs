using Dapper.Contrib.Extensions;

namespace Backend.DataAccessLibrary;

using Dapper;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{
    private readonly IConnectionFactory _connectionFactory;
    public GenericRepository(IConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }
    public void Add(TEntity entity)
    {
        _connectionFactory.GetConnection.Insert<TEntity>(entity);
    }

    public void Delete(TEntity entity)
    {
        _connectionFactory.GetConnection.Delete<TEntity>(entity);
    }

    public TEntity Get(int Id)
    {
        return _connectionFactory.GetConnection.Get<TEntity>(Id);
    }

    public IEnumerable<TEntity> GetAll()
    {
        return _connectionFactory.GetConnection.GetAll<TEntity>().ToList();
    }

    public void Update(TEntity entity)
    {
        _connectionFactory.GetConnection.Update<TEntity>(entity);
    }
}