using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Backend.DAL_EF;
using Backend.DataAccessLibrary;
using Backend.Services.Interface;
using Backend.Shared.Dtos;
using Backend.Shared.Dtos.UserDtos;
using Mapster;
using Microsoft.IdentityModel.Tokens;

namespace Backend.Services.Services;

public class UserService : IUserService
{
    private readonly ApplicationDbContext _applicationDbContext;
    private readonly IJwtConfiguration _jwtConfiguration;
    private readonly TokenValidationParameters _tokenValidationParameters;
    public UserService(ApplicationDbContext applicationDbContext, IJwtConfiguration jwtConfiguration, TokenValidationParameters tokenValidationParameters)
    {
        _jwtConfiguration = jwtConfiguration;
        _tokenValidationParameters = tokenValidationParameters;
        _applicationDbContext = applicationDbContext;
    }
    /// <summary>
    /// this method adds User with default service point
    /// also login user and returns json web token
    /// </summary>
    /// <param name="login"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    public void RegisterUser(string login, string password)
    {
        var user = new User()
        {
            Login = login,
            Password =  BCrypt.Net.BCrypt.HashPassword(password),
        };
        
        var addedUser = _applicationDbContext.Users.Add(user);

        _applicationDbContext.SaveChanges();
        
        var refreshToken = new RefreshToken
        {
            Token = GenerateRefreshToken(),
            ExpirationTime = DateTime.Now.AddMonths(1),
            UserId = addedUser.Entity.Id
        };

        _applicationDbContext.RefreshTokens.Add(refreshToken);
        _applicationDbContext.SaveChanges();
    }

    
    /// <summary>
    /// authenticate user and returns json web token if authentication pass
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public AuthenticatedUserResposeDto LoginUser(LoginUserDto user)
    {
        var authenticatedUser =
                _applicationDbContext.Users.FirstOrDefault(x => x.Login.Equals(user.Login));
        if (authenticatedUser == default)
        {
            return null;
        }

        if (!BCrypt.Net.BCrypt.Verify(user.Password, authenticatedUser.Password))
        {
            return null;
        }

        var refreshToken = _applicationDbContext.RefreshTokens.FirstOrDefault(x =>
            x.UserId.Equals(authenticatedUser.Id) && x.ExpirationTime > DateTime.Now);
        if (refreshToken == default)
        {
            return null;
        }

        var token = GenerateJsonWebToken(user);
        return new AuthenticatedUserResposeDto { RefreshToken = refreshToken.Token, Token = token };
    }

    public AuthenticatedUserResposeDto RefreshToken(string refreshToken, string accessToken)
    {
        //validate accessToken
        var tokenHandler = new JwtSecurityTokenHandler();
        SecurityToken securityToken;
        var principal = tokenHandler.ValidateToken(accessToken, _tokenValidationParameters, out securityToken);
        var jwtSecurityToken = securityToken as JwtSecurityToken;
        if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            throw new SecurityTokenException("Invalid token");
        var userLogin = principal.Claims.FirstOrDefault(x => x.Type.Equals("userLogin")).Value;
        var user = _applicationDbContext.Users.FirstOrDefault(x=>x.Login.Equals(userLogin));
        if (_applicationDbContext.RefreshTokens.Any(x => x.UserId.Equals(user.Id) && x.Token.Equals(refreshToken) && x.ExpirationTime > DateTime.Now))
        {
            return new AuthenticatedUserResposeDto
            {
                RefreshToken = refreshToken,
                Token = GenerateJsonWebToken(user.Adapt<LoginUserDto>())
            };
        }
        else
        {
            return null;
        }
    }
    
    #region Private functions
   
    private string GenerateJsonWebToken(LoginUserDto userDto)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfiguration.Key));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        //here i can add any claims
        var claims = new[] {    
            new Claim("userLogin", userDto.Login),
        };


        var issuer = _jwtConfiguration.Issuer;
        var token = new JwtSecurityToken(
            issuer,
            issuer,
            claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private string GenerateRefreshToken()
    {
        var randomNumber = new byte[32];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber);
    }
    #endregion

}