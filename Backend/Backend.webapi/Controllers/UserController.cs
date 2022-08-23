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
    public IActionResult RegisterUser(string login, string password)
    {
        try
        {
            return Ok(_userService.RegisterUser(login, password));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost("Login")]
    public IActionResult Login([FromBody] UserDto user)
    {
        IActionResult response = Unauthorized();
        var userDto = _userService.AuthenticateUser(user);

        if (userDto != null)
        {
            var tokenString = _userService.GenerateJsonWebToken(user);
            response = Ok(new { token = tokenString });
        }

        return response;
    }
}