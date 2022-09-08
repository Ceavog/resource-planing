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
    public IActionResult RegisterUser([FromBody]UserDto user)
    {
        try
        {
            var tokenString = _userService.RegisterUser(user.Login, user.Password);
            return Ok(tokenString);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost("LoginUser")]
    public IActionResult Login([FromBody] UserDto user)
    {
        var tokenString = _userService.LoginUser(user);
        if (tokenString != "unauthorized")
        {
            return Ok(tokenString);
        }
        else
        {
            return Unauthorized();
        }
    }
}