using Backend.Shared.Dtos.CategoryDtos;

namespace Backend.Services.Interface;

public interface ICategoryService
{
    AddCategoryDto AddCategory(AddCategoryDto addCategoryDto);
    IEnumerable<GetCategoryDto> GetAllCategoriesForUserId(int userId);
}