namespace Backend.DataAccessLibrary;

public class OrderPosition
{
    public int Id { get; set; }
    
    public int OrderId { get; set; }
    public Order Order { get; set; }
    
    public int ManuPositionId { get; set; }
    public MenuPosition MenuPosition { get; set; }
    
    
}