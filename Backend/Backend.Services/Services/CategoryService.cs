using Backend.DataAccessLibrary;
using Backend.Repository.Interfaces;
using Backend.Services.Interface;
using Backend.Shared.Dtos.CategoryDtos;
using Mapster;

namespace Backend.Services.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUserRepository _userRepository;
    public CategoryService(ICategoryRepository categoryRepository, IUserRepository userRepository)
    {
        _categoryRepository = categoryRepository;
        _userRepository = userRepository;
    }

    public AddCategoryDto AddCategory(AddCategoryDto addCategoryDto)
    {
        return _categoryRepository.Add(addCategoryDto.Adapt<Category>()).Adapt<AddCategoryDto>();
    }

    public IEnumerable<GetCategoryDto> GetAllCategoriesForUserId(int userId)
    {
        _userRepository.ThrowExceptionWhenUserWithGivenIdDoesNotExists(userId);
        return _categoryRepository.GetAllCategoriesForUserId(userId).Adapt<IEnumerable<GetCategoryDto>>();
    }
}