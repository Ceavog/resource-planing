using Backend.DAL_EF;
using Backend.DataAccessLibrary;
using Backend.Repository.GenericRepositories;
using Backend.Repository.Interfaces;

namespace Backend.Repository;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    private readonly ApplicationException _applicationException;
    public CategoryRepository(ApplicationDbContext applicationDbContext, ApplicationException applicationException) 
        : base(applicationDbContext)
    {
        _applicationException = applicationException;
    }
    
    
}