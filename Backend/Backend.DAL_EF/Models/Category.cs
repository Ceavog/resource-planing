namespace Backend.DataAccessLibrary;

public class Category{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public int ServicePointId { get; set; }
    public ServicePoint ServicePoint { get; set; }
}