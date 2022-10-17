using Backend.Services.Interface;
using Backend.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.webapi;

[ApiController]
public class ExampleController : Controller
{
    [HttpGet("example1")]
    public IActionResult GetSampleString1()
    {
        return Ok("example");
    }
}