namespace Backend.DataAccessLibrary;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string SecondName { get; set; }
    public int ServicePointId { get; set; }
    public ServicePoint ServicePoint { get; set; }
    public string test { get; set; }
}