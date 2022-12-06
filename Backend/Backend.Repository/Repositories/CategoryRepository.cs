using Backend.DAL_EF;
using Backend.DataAccessLibrary;
using Backend.Repository.GenericRepositories;
using Backend.Repository.Interfaces;
using Backend.Shared.Exceptions.CategoryExceptions;

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

    public void ThrowExceptionWhenCategoryWithGivenIdDoesNotExists(int categoryId)
    {
        if (!_applicationDbContext.Categories.Any(x => x.Id.Equals(categoryId)))
            throw new CategoryWithGivenIdDoesNotExistsException(categoryId);
    }

    public Category UpdateCategory(Category category)
    {
        _applicationDbContext.ChangeTracker.Clear();
        var updatedCategory = _applicationDbContext.Categories.Update(category).Entity;
        _applicationDbContext.SaveChanges();
        return updatedCategory;
    }

    public void ThrowExceptionWhenCategoryWithGivenNameAlreadyExistsForUserWithGivenId(string categoryName, int userId)
    {
        if (_applicationDbContext.Categories.Any(x => x.Name.Equals(categoryName) && x.UserId.Equals(userId)))
            throw new CategoryWithGivenNameAndUserWithThisIdAlreadyExistsException(categoryName, userId);
    }
}