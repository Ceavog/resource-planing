using Backend.Services.Interface;
using Backend.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.webapi;

[ApiController]
public class ExampleController : Controller
{
    private readonly ICategoryService _categoryService;

    public ExampleController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    [HttpGet("example")]
    public IActionResult GetSampleString()
    {
        return Ok(_categoryService.GetTypeName_(1));
    }
    
    [HttpGet("example1")]
    public IActionResult GetSampleString1()
    {
        return Ok("example");
    }
}