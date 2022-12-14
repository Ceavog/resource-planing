using Backend.DataAccessLibrary;
using Backend.Repository.Interfaces;
using Backend.Services.Interface;
using Backend.Shared.Dtos.CategoryDtos;
using Backend.Shared.Dtos.ProductDtos;
using Backend.Shared.Exceptions.CategoryExceptions;
using Backend.Shared.Exceptions.UserExceptions;
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
        if (!_userRepository.CheckIfUserWithGivenIdExists(addCategoryDto.UserId))
            throw new UserWithGivenIdDoesNotExistsException(addCategoryDto.UserId);
        if (!_categoryRepository.CheckIfCategoryWithGivenNameAlreadyExistsForUserWithGivenId(addCategoryDto.Name,
                addCategoryDto.UserId))
            throw new CategoryWithGivenNameAndUserWithThisIdAlreadyExistsException(addCategoryDto.Name,
                addCategoryDto.UserId);
        
        return _categoryRepository.Add(addCategoryDto.Adapt<Category>()).Adapt<AddCategoryDto>();
    }

    public IEnumerable<GetCategoryDto> GetAllCategoriesForUserId(int userId)
    {
        //_userRepository.ThrowExceptionWhenUserWithGivenIdDoesNotExists(userId);
        if (!_userRepository.CheckIfUserWithGivenIdExists(userId))
            throw new UserWithGivenIdDoesNotExistsException(userId);
        return _categoryRepository.GetAllCategoriesForUserId(userId).Adapt<IEnumerable<GetCategoryDto>>();
    }

    public UpdateCategoryDto UpdateCategory(UpdateCategoryDto updateCategoryDto)
    {
        if (!_userRepository.CheckIfUserWithGivenIdExists(updateCategoryDto.UserId))
            throw new UserWithGivenIdDoesNotExistsException(updateCategoryDto.UserId);

        if (!_categoryRepository.CheckIfCategoryWithGivenIdExists(updateCategoryDto.Id))
            throw new CategoryWithGivenIdDoesNotExistsException(updateCategoryDto.Id);
        
        if (!_categoryRepository.CheckIfCategoryWithGivenNameAlreadyExistsForUserWithGivenId(updateCategoryDto.Name,
                updateCategoryDto.UserId))
            throw new CategoryWithGivenNameAndUserWithThisIdAlreadyExistsException(updateCategoryDto.Name,
                updateCategoryDto.UserId);
        
        
        return _categoryRepository.UpdateCategory(updateCategoryDto.Adapt<Category>()).Adapt<UpdateCategoryDto>();
    }

    public CategoryDto DeleteCategory(int categoryId)
    {
        
        if (!_categoryRepository.CheckIfCategoryWithGivenIdExists(categoryId))
            throw new CategoryWithGivenIdDoesNotExistsException(categoryId);
        
        return _categoryRepository.Delete(categoryId).Adapt<CategoryDto>();
    }

    public IEnumerable<GetCategoryWithProductsDto> GetCategoryWithProducts(int userId)
    {
        if (!_userRepository.CheckIfUserWithGivenIdExists(userId))
            throw new UserWithGivenIdDoesNotExistsException(userId);
        
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