namespace Backend.Services.Interface;

public interface IUserService
{
    long RegisterUser(string login, string password);
}