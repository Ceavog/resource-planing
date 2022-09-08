using Backend.DataAccessLibrary;
using Backend.Shared.Dtos;

namespace Backend.Services.Interface;

public interface IUserService
{
    string RegisterUser(string login, string password);
    string LoginUser(UserDto user);
}