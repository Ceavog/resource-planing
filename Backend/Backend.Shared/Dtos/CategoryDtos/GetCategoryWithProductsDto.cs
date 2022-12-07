using Backend.Shared.Dtos.ProductDtos;

namespace Backend.Shared.Dtos.CategoryDtos;

public class GetCategoryWithProductsDto
{
    public CategoryDto Category { get; set; }
    public IEnumerable<ProductDto> Products { get; set; }
}