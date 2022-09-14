using Backend.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.webapi;

[ApiController]
[Authorize]
public class CategoryController : Controller
{
    private readonly ICategoryService _categoryService;
    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet("CategoryWithMenuPositions")]
    public IActionResult GetCategoryWithMenuPositions(int servicePointId)
    {
        try
        {
            return Ok(_categoryService.GetCategoryWithMenuPositionsByServicePointId(servicePointId));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

}