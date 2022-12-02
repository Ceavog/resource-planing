using Backend.DataAccessLibrary;
using Backend.Repository.Interfaces;
using Backend.Services.Interface;
using Backend.Shared.Dtos.CategoryDtos;
using Mapster;

namespace Backend.Services.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public AddCategoryDto AddCategory(AddCategoryDto addCategoryDto)
    {
        return _categoryRepository.Add(addCategoryDto.Adapt<Category>()).Adapt<AddCategoryDto>();
    }
}