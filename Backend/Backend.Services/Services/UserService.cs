using Backend.DAL_EF;
using Backend.DataAccessLibrary;
using Backend.Services.Interface;
using BCrypt.Net;

namespace Backend.Services.Services;

public class UserService : IUserService
{
    private readonly ApplicationDbContext _applicationDbContext;
    public UserService(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }
    /// <summary>
    /// this method adds User with default service point 
    /// </summary>
    /// <param name="login"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    public User RegisterUser(string login, string password)
    {
        password = BCrypt.Net.BCrypt.HashPassword(password);
        var user = new User()
        {
            login = login,
            Password = password,
            ServicePointId = 1
        };
        var addedUser =_applicationDbContext.Users.Add(user).Entity;
        _applicationDbContext.SaveChanges();
        return addedUser;
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