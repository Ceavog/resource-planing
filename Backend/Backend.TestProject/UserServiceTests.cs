using Backend.DAL_EF;
using Backend.Repository;
using Backend.Services;
using Backend.Services.Interface;
using Backend.Services.Services;
using Backend.Shared.Dtos;
using Microsoft.IdentityModel.Tokens;
using FluentAssertions;
using FluentAssertions.Common;
using Moq;

namespace Backend.TestProject;

[TestFixture]
public class UserServiceTests
{
    private UserService _userService;
    private ApplicationDbContext _applicationDbContext;
    private UserRepository _userRepo;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        var jwtConfig = new JwtConfiguration()
        {
            Issuer = "localhost:5000",
            Key = "ThisismySecretKey"
        };
        var tokenValidationParams = new TokenValidationParameters();
        _applicationDbContext = new ApplicationDbContext();
        _userRepo = new UserRepository(_applicationDbContext);
        var refreshTokenRepo = new RefreshTokenRepository(_applicationDbContext);
        _userService = new UserService(jwtConfig, tokenValidationParams, _userRepo, refreshTokenRepo);
    }

    [Test]
    public void RegisterUser_ShouldCheckIfUserWithGivenLoginExists()
    {
        //arrange
        var randomLogin = Guid.NewGuid().ToString();
        _userService.RegisterUser(randomLogin, "password");
        
        //act
        Action result = () => _userService.RegisterUser(randomLogin, "password1");

        //assert 
        result.Should().ThrowExactly<ArgumentException>().WithMessage("This login already exists");


        var user = _applicationDbContext.Users.First(x => x.Login.Equals(randomLogin));
        _applicationDbContext.Users.Remove(user);
        _applicationDbContext.RefreshTokens.Remove(
            _applicationDbContext.RefreshTokens.First(x => x.UserId.Equals(user.Id)));
        _applicationDbContext.SaveChanges();
    }

    [Test]
    public void LoginUser_ShouldThrowException_WhenThereIsNoLoginInDb()
    {
        var randomLogin = Guid.NewGuid().ToString();
        var user = new LoginUserDto()
        {
            Login = randomLogin,
            Password = "password"
        };

        Action result = () => _userService.LoginUser(user);

        result.Should().ThrowExactly<ArgumentException>().WithMessage("Login does not exists");
        
    }

    [Test]
    public void LoginUser_ShouldThrowException_WhenPasswordDoesntMatch()
    {
        var randomLogin = Guid.NewGuid().ToString();
        _userService.RegisterUser(randomLogin, "password");
        var user = new LoginUserDto()
        {
            Login = randomLogin,
            Password = "password1"
        };

        Action result = () => _userService.LoginUser(user);

        result.Should().ThrowExactly<ArgumentException>();
    }

    [Test]
    public void LoginUser_ShouldGenerateNewRefreshTokenIfDoesNotExistsForUser()
    {
        var randomLogin = Guid.NewGuid().ToString();
        _userService.RegisterUser(randomLogin, "password");
        var user = _applicationDbContext.Users.First(x => x.Login.Equals(randomLogin));
        _applicationDbContext.RefreshTokens.Remove(
            _applicationDbContext.RefreshTokens.First(x => x.UserId.Equals(user.Id)));
        _applicationDbContext.SaveChanges();
        var userToLogin = new LoginUserDto()
        {
            Login = randomLogin,
            Password = "password"
        };

        _userService.LoginUser(userToLogin);
        
        bool refreshTokenExists = _applicationDbContext.RefreshTokens.Any(x => x.UserId.Equals(user.Id));
            
        refreshTokenExists.Should().BeTrue();
        
        _applicationDbContext.Users.Remove(user);
        _applicationDbContext.RefreshTokens.Remove(
            _applicationDbContext.RefreshTokens.First(x => x.UserId.Equals(user.Id)));
        _applicationDbContext.SaveChanges();
    }
}