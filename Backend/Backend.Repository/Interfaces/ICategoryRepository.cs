using Backend.DataAccessLibrary;
using Backend.Repository.GenericRepositories;

namespace Backend.Repository.Interfaces;

public interface ICategoryRepository : IGenericRepository<Category>
{
    IEnumerable<Category> GetAllCategoriesForUserId(int userId);
    void ThrowExceptionWhenCategoryWithGivenIdDoesNotExists(int categoryId);
    Category UpdateCategory(Category category);

}