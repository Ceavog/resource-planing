using Backend.Services.Interface;
using Backend.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Backend.webapi;

[ApiController]
public class UserController : Controller
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    [HttpPost("RegisterUser")]
    public IActionResult RegidefaultsterUser(string login, string password)
    {
        try
        {
            _userService.RegisterUser(login, password);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost("LoginUser")]
    public IActionResult Login(string login, string password)
    {
        var authenticatedUserRespose = _userService.LoginUser(new LoginUserDto{Login = login, Password = password});
        if (authenticatedUserRespose != null)
        {
            return Ok(authenticatedUserRespose);
        }
        else
        {
            return Unauthorized();
        }
    }

    [HttpPost("RefreshToken")]
    public IActionResult RefreshToken(string expiredToken, string refreshToken)
    {
        var refreshedTokenResponse = _userService.RefreshToken(refreshToken, expiredToken);
        if (refreshedTokenResponse != null)
        {
            return Ok(refreshedTokenResponse);
        }
        else
        {
            return Unauthorized();
        }
    }
    

}