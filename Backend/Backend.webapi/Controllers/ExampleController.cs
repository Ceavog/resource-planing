using Backend.Services.Interface;
using Backend.Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.webapi;

[ApiController]
[Authorize]
public class ExampleController : Controller
{
    [HttpGet("example1")]
    public IActionResult GetSampleString1()
    {
        return Ok("example");
    }
}