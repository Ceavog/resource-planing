using Backend.DataAccessLibrary;
using Backend.Services.Interface;
using BCrypt.Net;

namespace Backend.Services.Services;

public class UserService : IUserService
{
    public long RegisterUser(string login, string password)
    {
        // password = BCrypt.Net.BCrypt.HashPassword(password);        
        // var user = new ServicePoint()
        // {
        //     Login = login,
        //     Password = password
        // };
        // var id = _unitOfWork._UserRepository.Add(user);
        // _unitOfWork.Commit();
        // _unitOfWork.Dispose();
        // return id;
        throw new NotImplementedException();
    }

    public void Login(string login, string password)
    {
        throw new NotImplementedException();
    }

    // public AuthenticateResponse Login(string login, string password)
    // {
    //     var user = _unitOfWork._UserRepository.GetAllByCondition($"login = {login}").First();
    //
    //     if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.Password))
    //         throw new Exception("Username or password is incorrect");
    //     
    // }
}