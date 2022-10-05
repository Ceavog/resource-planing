namespace Backend.Shared.Dtos;

public class RegisterUserDto
{
    public int Id { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public string ServicePointAddress { get; set; }
}