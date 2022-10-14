namespace Backend.DataAccessLibrary;

public class Order
{
    public int Id { get; set; }
    // public int EmployeeId { get; set; }
    // public Employee Employee { get; set; }
    
    public DateTime OrderTime { get; set; }
    
    private ICollection<OrderPosition> OrderPositions { get; set; }

    
    // public int ServicePointId { get; set; }
    // public ServicePoint ServicePoint { get; set; }
    
    public int OrderTypeId { get; set; }
    public OrderType OrderType { get; set; }
}