using Backend.DataAccessLibrary;
using Backend.DataAccessLibrary.UnitOfWork;
using Backend.Services.Interface;
using BCrypt.Net;

namespace Backend.Services.Services;

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;
    
    public UserService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public long RegisterUser(string login, string password)
    {

        password = BCrypt.Net.BCrypt.HashPassword(password);        
        var user = new User()
        {
            Login = login,
            Password = password
        };
        var id = _unitOfWork._UserRepository.Add(user);
        _unitOfWork.Commit();
        _unitOfWork.Dispose();
        return id;

    }
}