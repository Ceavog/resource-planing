using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Backend.DAL_EF;
using Backend.DataAccessLibrary;
using Backend.Repository;
using Backend.Repository.GenericRepositories;
using Backend.Repository.Interfaces;
using Backend.Services.Interface;
using Backend.Shared.Dtos;
using Backend.Shared.Dtos.UserDtos;
using Mapster;
using Microsoft.IdentityModel.Tokens;

namespace Backend.Services.Services;

public class UserService : IUserService
{
    private readonly IJwtConfiguration _jwtConfiguration;
    private readonly TokenValidationParameters _tokenValidationParameters;
    private readonly IUserRepository _userRepository;
    private readonly IRefreshTokenRepository _refreshTokenRepository;
    public UserService(IJwtConfiguration jwtConfiguration, TokenValidationParameters tokenValidationParameters, IUserRepository userRepository, IRefreshTokenRepository refreshTokenRepository)
    {
        _jwtConfiguration = jwtConfiguration;
        _tokenValidationParameters = tokenValidationParameters;
        _userRepository = userRepository;
        _refreshTokenRepository = refreshTokenRepository;
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
        if (_userRepository.CheckIfLoginExists(login))
        {
            throw new ArgumentException("This login already exists");
        }   
        var user = new User()
        {
            Login = login,
            Password =  BCrypt.Net.BCrypt.HashPassword(password),
        };
        
        var addedUser = _userRepository.Add(user);

        var refreshToken = GenerateRefreshToken(addedUser.Id);
        _refreshTokenRepository.Add(refreshToken);
        // _applicationDbContext.RefreshTokens.Add(refreshToken);
        // _applicationDbContext.SaveChanges();
    }

    
    /// <summary>
    /// authenticate user and returns json web token if authentication pass
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public AuthenticatedUserResposeDto LoginUser(LoginUserDto user)
    {
        var authenticatedUser = _userRepository.GetUserByLogin(user.Login);
        if (authenticatedUser == null)
        {
            throw new ArgumentException("Login does not exists");
        }

        if (!BCrypt.Net.BCrypt.Verify(user.Password, authenticatedUser.Password))
        {
            throw new ArgumentException();

        }

        // var refreshToken = _applicationDbContext.RefreshTokens.FirstOrDefault(x =>
        //     x.UserId.Equals(authenticatedUser.Id) && x.ExpirationTime > DateTime.Now);
        var refreshToken = _refreshTokenRepository.GetRefreshTokenByUserId(authenticatedUser.Id);
        if (refreshToken == null)
        {
            refreshToken = GenerateRefreshToken(authenticatedUser.Id);
            _refreshTokenRepository.Add(refreshToken);
        }

        var token = GenerateJsonWebToken(user);
        return new AuthenticatedUserResposeDto { RefreshToken = refreshToken.Token, Token = token };
    }

    public AuthenticatedUserResposeDto RefreshToken(string refreshToken, string accessToken)
    {
        //validate accessToken
        var tokenHandler = new JwtSecurityTokenHandler();
        var principal = tokenHandler.ValidateToken(accessToken, _tokenValidationParameters, out var securityToken);
        var jwtSecurityToken = securityToken as JwtSecurityToken;
        if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            throw new SecurityTokenException("Invalid token");
        var userLogin = principal.Claims.FirstOrDefault(x => x.Type.Equals("userLogin")).Value;
        // var user = _applicationDbContext.Users.FirstOrDefault(x=>x.Login.Equals(userLogin));
        var user = _userRepository.GetUserByLogin(userLogin);
        if (_refreshTokenRepository.CheckIfUserWithGivenRefreshTokenExists(user.Id, refreshToken))
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

    private RefreshToken GenerateRefreshToken(int addedUserId)
    {
        var randomNumber = new byte[32];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        
        var refreshToken = new RefreshToken
        {
            Token = Convert.ToBase64String(randomNumber),
            ExpirationTime = DateTime.Now.AddMonths(1),
            UserId = addedUserId
        };
        return refreshToken;
    }
    #endregion

}