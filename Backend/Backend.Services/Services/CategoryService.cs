using Backend.DataAccessLibrary;
using Backend.Repository.Interfaces;
using Backend.Services.Interface;
using Backend.Shared.Dtos.CategoryDtos;
using Backend.Shared.Dtos.ProductDtos;
using Mapster;
using GetCategoryWithProductsDto = Backend.Shared.Dtos.ProductCategoryDtos.GetCategoryWithProductsDto;

namespace Backend.Services.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUserRepository _userRepository;
    private readonly IProductsRepository _productsRepository;
    public CategoryService(ICategoryRepository categoryRepository, IUserRepository userRepository, IProductsRepository productsRepository)
    {
        _categoryRepository = categoryRepository;
        _userRepository = userRepository;
        _productsRepository = productsRepository;
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

    public IEnumerable<GetCategoryWithProductsDto> GetCategoryWithProducts(int userId)
    {
        _userRepository.ThrowExceptionWhenUserWithGivenIdDoesNotExists(userId);
        var categoriesWithProducts = new List<GetCategoryWithProductsDto>();
        var categories = _categoryRepository.GetAllCategoriesForUserId(userId);
        foreach (var category in categories)
        {
            var categoryWithProduct = new GetCategoryWithProductsDto
            {
                Category = category.Adapt<CategoryDto>(),
                Products = _productsRepository.GetAllProductsByCategoryId(category.Id).Adapt<IEnumerable<ProductDto>>()
            };
            categoriesWithProducts.Add(categoryWithProduct);
        }

        return categoriesWithProducts;
    }
}