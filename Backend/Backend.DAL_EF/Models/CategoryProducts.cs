namespace Backend.DataAccessLibrary;

public class CategoryProducts
{
    public int Id { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }

    public int ProductId { get; set; }
    public Products Products { get; set; }
}