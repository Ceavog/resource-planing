using Backend.DataAccessLibrary;
using Backend.Repository.Interfaces;
using Backend.Services.Interface;
using Backend.Shared.Dtos.CategoryDtos;
using Backend.Shared.Dtos.ProductDtos;
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
        _userRepository.ThrowExceptionWhenUserWithGivenIdDoesNotExists(addCategoryDto.UserId);
        _categoryRepository.ThrowExceptionWhenCategoryWithGivenNameAlreadyExistsForUserWithGivenId(addCategoryDto.Name, addCategoryDto.UserId);
        
        return _categoryRepository.Add(addCategoryDto.Adapt<Category>()).Adapt<AddCategoryDto>();
    }

    public IEnumerable<GetCategoryDto> GetAllCategoriesForUserId(int userId)
    {
        _userRepository.ThrowExceptionWhenUserWithGivenIdDoesNotExists(userId);
        return _categoryRepository.GetAllCategoriesForUserId(userId).Adapt<IEnumerable<GetCategoryDto>>();
    }

    public UpdateCategoryDto UpdateCategory(UpdateCategoryDto updateCategoryDto)
    {
        _userRepository.ThrowExceptionWhenUserWithGivenIdDoesNotExists(updateCategoryDto.UserId);
        _categoryRepository.ThrowExceptionWhenCategoryWithGivenIdDoesNotExists(updateCategoryDto.Id);
        _categoryRepository.ThrowExceptionWhenCategoryWithGivenNameAlreadyExistsForUserWithGivenId(updateCategoryDto.Name,updateCategoryDto.UserId);
        
        return _categoryRepository.UpdateCategory(updateCategoryDto.Adapt<Category>()).Adapt<UpdateCategoryDto>();
    }

    public CategoryDto DeleteCategory(int categoryId)
    {
        _categoryRepository.ThrowExceptionWhenCategoryWithGivenIdDoesNotExists(categoryId);
        return _categoryRepository.Delete(categoryId).Adapt<CategoryDto>();
    }
}