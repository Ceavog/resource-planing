using Microsoft.AspNetCore.Mvc;

namespace Backend.webapi;

[ApiController]
public class ExampleController : Controller
{
    [HttpGet("example")]
    public IActionResult GetSampleString()
    {
        return Ok("example string");
    }
}