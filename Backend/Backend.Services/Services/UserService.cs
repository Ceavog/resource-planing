using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Backend.DAL_EF;
using Backend.DataAccessLibrary;
using Backend.Services.Interface;
using Backend.Shared.Dtos;
using BCrypt.Net;
using Mapster;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

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

    public UserDto AuthenticateUser(UserDto userDto)
    {
        var user = _applicationDbContext.Users.FirstOrDefault(x => x.login.Equals(userDto.Login));
        return BCrypt.Net.BCrypt.Verify(userDto.Password,user.Password) ? user.Adapt<UserDto>() : null;
    }

    
    public string GenerateJsonWebToken(UserDto userDto)
    {
        var key = "ThisismySecretKey";
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        //here i can add any claims
        var claims = new[] {    
            new Claim("userId", userDto.Id.ToString()),
            new Claim("userLogin", userDto.Login),
        };

        
        var isuer = "https://localhost:7161/";
        var token = new JwtSecurityToken(
            isuer,
            isuer,
            claims,
            expires: DateTime.Now.AddMinutes(2),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}