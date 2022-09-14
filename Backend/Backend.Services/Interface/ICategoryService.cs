using Backend.Shared.Dtos;

namespace Backend.Services.Interface;

public interface ICategoryService
{
    IEnumerable<CategoryWithMenuPositionsDto> GetCategoryWithMenuPositionsByServicePointId(int servicePointId);
}