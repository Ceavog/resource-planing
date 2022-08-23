using Backend.DataAccessLibrary;
using Backend.Shared.Dtos;

namespace Backend.Services.Interface;

public interface IUserService
{
    User RegisterUser(string login, string password);
    UserDto AuthenticateUser(UserDto user);
    string GenerateJsonWebToken(UserDto user);
}