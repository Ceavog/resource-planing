namespace Shared.Models;

public class MenuPositionsModel
{
    public int Id { get; set; }
    public int CategoryId { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public string Section { get; set; }
}