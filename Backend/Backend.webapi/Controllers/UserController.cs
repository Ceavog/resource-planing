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

    [HttpPost("LoginUser")]
    public IActionResult Login(string login, string password)
    {
        try
        {
            var authenticatedUserResponse = _userService.LoginUser(new LoginUserDto { Login = login, Password = password });
            Response.Cookies.Append("X-Access-Token", authenticatedUserResponse.Token, new CookieOptions() { HttpOnly = true });
            Response.Cookies.Append("X-Refresh-Token", authenticatedUserResponse.RefreshToken, new CookieOptions() {HttpOnly = true});
            return Ok();
        }
        catch (Exception e)
        {
            return Unauthorized();
        }
    }

    [HttpGet("RefreshToken")]
    public IActionResult RefreshToken()
    {
        try
        {
            Request.Cookies.TryGetValue("X-Refresh-Token", out var refreshToken);
            Request.Cookies.TryGetValue("X-Access-Token", out var accessToken);

            if (accessToken is null && refreshToken is null)
                return BadRequest();
            var authenticatedUserResponse = _userService.RefreshToken(refreshToken, accessToken);
            
            Response.Cookies.Append("X-Access-Token", authenticatedUserResponse.Token, new CookieOptions() { HttpOnly = true });
            Response.Cookies.Append("X-Refresh-Token", authenticatedUserResponse.RefreshToken, new CookieOptions() {HttpOnly = true});

            return Ok();
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