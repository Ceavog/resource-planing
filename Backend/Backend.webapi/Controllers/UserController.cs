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
            return Ok(_userService.RegisterUser(user.Login, user.Password));
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
            return Ok(new { token = tokenString });
        }
        else
        {
            return Unauthorized();
        }
        // IActionResult response = Unauthorized();
        // var userDto = _userService.AuthenticateUser(user);
        //
        // if (userDto != null)
        // {
        //     var tokenString = _userService.GenerateJsonWebToken(user);
        //     response = Ok(new { token = tokenString });
        // }
        //
        // return Json(response);
    }
}