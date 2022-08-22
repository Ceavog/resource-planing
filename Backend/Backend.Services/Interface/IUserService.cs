using Backend.DataAccessLibrary;

namespace Backend.Services.Interface;

public interface IUserService
{
    User RegisterUser(string login, string password);
    void Login(string login, string password);
}