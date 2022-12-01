namespace Backend.Shared.Dtos.ProductDtos;

public class GetProductDto
{
    public string Name { get; set; }
    public double Price { get; set; }
    public string Section { get; set; }
    public int UserId { get; set; }
}