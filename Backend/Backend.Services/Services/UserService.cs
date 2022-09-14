using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Backend.DAL_EF;
using Backend.DataAccessLibrary;
using Backend.Services.Interface;
using Backend.Shared.Dtos;
using Mapster;
using Microsoft.IdentityModel.Tokens;

namespace Backend.Services.Services;

public class UserService : IUserService
{
    private readonly ApplicationDbContext _applicationDbContext;
    private readonly IJwtConfiguration _jwtConfiguration;
    public UserService(ApplicationDbContext applicationDbContext, IJwtConfiguration jwtConfiguration)
    {
        _jwtConfiguration = jwtConfiguration;
        _applicationDbContext = applicationDbContext;
    }
    /// <summary>
    /// this method adds User with default service point
    /// also login user and returns json web token
    /// </summary>
    /// <param name="login"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    public string RegisterUser(string login, string password)
    {
        var user = new User()
        {
            Login = login,
            Password =  BCrypt.Net.BCrypt.HashPassword(password),
            ServicePointId = 1
        };
        
        _applicationDbContext.Users.Add(user);
        _applicationDbContext.SaveChanges();

        var userToLogin = new User()
        {
            Login = login,
            Password = password
        };
        var token = LoginUser(userToLogin.Adapt<UserDto>());
        return token;
    }

    
    /// <summary>
    /// authenticate user and returns json web token if authentication pass
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public string LoginUser(UserDto user)
    {
        var authenticatedUser = AuthenticateUser(user);
        if (authenticatedUser != null)
        {
             return GenerateJsonWebToken(authenticatedUser);
        }
        else
        {
            return "unauthorized";
        }
    }
 
    
    #region Private functions
    private UserDto AuthenticateUser(UserDto userDto)
    {
        var user = _applicationDbContext.Users.FirstOrDefault(x => x.Login.Equals(userDto.Login));
        if (user != null)
        {
            return BCrypt.Net.BCrypt.Verify(userDto.Password,user.Password) ? user.Adapt<UserDto>() : null;
        }
        else
        {
            return null;
        }
    }

    
    private string GenerateJsonWebToken(UserDto userDto)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfiguration.Key));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        //here i can add any claims
        var claims = new[] {    
            new Claim("userId", userDto.Id.ToString()),
            new Claim("userLogin", userDto.Login),
        };


        var issuer = _jwtConfiguration.Issuer;
        var token = new JwtSecurityToken(
            issuer,
            issuer,
            claims,
            expires: DateTime.Now.AddMinutes(2),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
    #endregion

}