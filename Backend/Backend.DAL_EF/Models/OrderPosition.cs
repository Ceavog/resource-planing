namespace Backend.DataAccessLibrary;

public class OrderPosition
{
    public int Id { get; set; }
    
    public int OrderId { get; set; }
    public Order Order { get; set; }
    
    public int ProductId { get; set; }
    public Products Products { get; set; }
    
    
}