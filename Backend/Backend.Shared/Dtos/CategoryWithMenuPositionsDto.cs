namespace Backend.Shared.Dtos;


/// <summary>
/// This dto should contain category object and list of positions in this category. 
/// </summary>
public class CategoryWithMenuPositionsDto
{
    public CategoryDto Category { get; set; }
    public IEnumerable<MenuPositionDto> MenuPosition { get; set; }
}