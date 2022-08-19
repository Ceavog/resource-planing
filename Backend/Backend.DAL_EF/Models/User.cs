namespace Backend.DataAccessLibrary;

public class User
{
    public int Id { get; set; }
    public string login { get; set; }
    public string Password { get; set; }
    public int ServicePointId { get; set; }
    public ServicePoint ServicePoint { get; set; }
}