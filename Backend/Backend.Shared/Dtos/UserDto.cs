namespace Backend.Shared.Dtos;

public class UserDto
{
    public int Id { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public int ServicePointId { get; set; }
}