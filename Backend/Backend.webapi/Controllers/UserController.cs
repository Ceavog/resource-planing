using Backend.Services.Interface;
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
}