using Backend.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.webapi;

[ApiController]
public class ExampleController : Controller
{
    private readonly CategoryService _categoryService;

    public ExampleController(CategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    [HttpGet("example")]
    public IActionResult GetSampleString()
    {
        return Ok(_categoryService.GetTypeName(1));
    }
}