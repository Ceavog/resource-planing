namespace Backend.DataAccessLibrary;

public class MenuPosition {
    public int Id { get; set; }
    
    public string Name { get; set; }
    public double Price { get; set; }
    public string Section { get; set; }
    
    // public int ServicePointId { get; set; }
    // public ServicePoint ServicePoint { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    
    private ICollection<OrderPosition> OrderPositions { get; set; }

}