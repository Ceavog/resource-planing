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
    public IActionResult GetCategoryWithMenuPositions(int userId)
    {
        try
        {
            return Ok(_categoryService.GetCategoryWithMenuPositionsByServicePointId(userId));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost("AddCategory")]
    public IActionResult AddCategory(int userId, string categoryName)
    {
        try
        {
            _categoryService.AddCategory(userId, categoryName);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost("UpdateCategoryById")]
    public IActionResult UpdateCategoryById(int categoryId, string newCategoryName)
    {
        try
        {
            _categoryService.EditCategory(categoryId, newCategoryName);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }  
    }

}