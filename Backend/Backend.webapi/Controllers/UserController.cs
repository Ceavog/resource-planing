using Backend.Services.Interface;
using Backend.Shared.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Backend.webapi;

[EnableCors("_myAllowSpecificOrigins")]
[ApiController]
public class UserController : Controller
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    
    [HttpPost("RegisterUser")]
    [EnableCors("_myAllowSpecificOrigins")]
    public IActionResult RegisterUser(string login, string password)
    {
        try
        {
            _userService.RegisterUser(login, password);
            return Ok();
        }
        catch (Exception e)
        {
            return Ok(e.Message);
        }

    }

    [HttpGet("LoginUser")]
    public IActionResult Login(string login, string password)
    {
        try
        {
            return Ok(_userService.LoginUser(new LoginUserDto{Login = login, Password = password}));
        }
        catch (Exception e)
        {
            return Unauthorized();
        }
    }

    [HttpGet("RefreshToken")]
    public IActionResult RefreshToken(string expiredToken, string refreshToken)
    {
        try
        {
            return Ok(_userService.RefreshToken(refreshToken, expiredToken));
        }
        catch (Exception e)
        {
            return Unauthorized();
        }
    }

    [HttpGet("Identity")]
    [Authorize]
    public IActionResult GetIdentity()
    {
        try
        {
            var jwtToken = Request.Headers["Authorization"].ToString();
            return Ok(_userService.GetAllDataAboutUser(jwtToken));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        
        
    }


    

}