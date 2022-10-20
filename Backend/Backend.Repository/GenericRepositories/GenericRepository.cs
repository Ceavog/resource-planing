using Backend.DAL_EF;

namespace Backend.Repository.GenericRepositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly ApplicationDbContext _applicationDbContext;
    public GenericRepository(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }
    public IEnumerable<T> GetAll()
    {
        throw new NotImplementedException();
    }

    public T Get(int id)
    {
        throw new NotImplementedException();
    }

    public T Add(T entity)
    {
        var addedEntity = _applicationDbContext.Set<T>().Add(entity);
        _applicationDbContext.SaveChanges();
        return addedEntity.Entity;
    }

    public T Update(T entity)
    {
        throw new NotImplementedException();
    }

    public T Delete(int id)
    {
        throw new NotImplementedException();
    }
}