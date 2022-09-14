namespace Backend.DataAccessLibrary;

public class CategoryPositions
{
    public int Id { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }

    public int MenuPositionId { get; set; }
    public MenuPosition MenuPosition { get; set; }
}