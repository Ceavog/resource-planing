using Backend.DAL_EF;
using Backend.Services.Interface;
using Backend.Shared.Dtos;
using Mapster;

namespace Backend.Services.Services;

public class CategoryService : ICategoryService
{
    private readonly ApplicationDbContext _applicationDbContext;

    public CategoryService(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }
    public IEnumerable<CategoryWithMenuPositionsDto> GetCategoryWithMenuPositionsByServicePointId(int servicePointId)
    {
        var categoryPositions =
            _applicationDbContext.CategoryPositions
                .Where(x=>x.ServicePointId.Equals(servicePointId))
                .Select(x=>x.CategoryId).Distinct().ToList();
        
        var CaTegoryWithMenuPositionsList = new List<CategoryWithMenuPositionsDto>();
        foreach (var categoryPositionId in categoryPositions)
        {
            CategoryWithMenuPositionsDto categoryWithMenuPositionsDto = new CategoryWithMenuPositionsDto();
            categoryWithMenuPositionsDto.Category = _applicationDbContext.Categories
                .FirstOrDefault(x => x.Id.Equals(categoryPositionId)).Adapt<CategoryDto>();
            var listOfInt =
                _applicationDbContext.CategoryPositions
                    .Where(x=>x.CategoryId.Equals(categoryPositionId))
                    .Select(x=>x.MenuPositionId).ToList();
            categoryWithMenuPositionsDto.MenuPosition =
                _applicationDbContext.MenuPositions.Where(x => listOfInt.Contains(x.Id)).ToList()
                    .Adapt<List<MenuPositionDto>>();
            CaTegoryWithMenuPositionsList.Add(categoryWithMenuPositionsDto);
        }

        return CaTegoryWithMenuPositionsList;
    }
}