using Backend.DAL_EF;
using Backend.DataAccessLibrary;
using Backend.Repository.GenericRepositories;
using Backend.Repository.Interfaces;

namespace Backend.Repository.Repositories;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    private readonly ApplicationDbContext _applicationDbContext;
    public CategoryRepository(ApplicationDbContext applicationDbContext) 
        : base(applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }
    
    public IEnumerable<Category> GetAllCategoriesForUserId(int userId)
    {
        return _applicationDbContext.Categories.Where(x => x.UserId.Equals(userId));
    }
    
}