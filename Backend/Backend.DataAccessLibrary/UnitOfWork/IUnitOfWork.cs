using System.Data;

namespace Backend.DataAccessLibrary.UnitOfWork;

public interface IUnitOfWork<TEntity> where TEntity : class
{
    void Commit();
    void Dispose();
    void Rollback();
    IGenericRepository<TEntity> _GenericRepository { get; }
}