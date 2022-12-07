using Backend.Shared.Dtos.CategoryDtos;
using GetCategoryWithProductsDto = Backend.Shared.Dtos.ProductCategoryDtos.GetCategoryWithProductsDto;

namespace Backend.Services.Interface;

public interface ICategoryService
{
    AddCategoryDto AddCategory(AddCategoryDto addCategoryDto);
    IEnumerable<GetCategoryDto> GetAllCategoriesForUserId(int userId);
    UpdateCategoryDto UpdateCategory(UpdateCategoryDto updateCategoryDto);
    CategoryDto DeleteCategory(int categoryId);
    IEnumerable<GetCategoryWithProductsDto> GetCategoryWithProducts(int userId);
}