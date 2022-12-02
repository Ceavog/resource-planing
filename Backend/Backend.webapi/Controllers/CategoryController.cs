using Backend.Services.Interface;
using Backend.Shared.Dtos.CategoryDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.webapi;

[ApiController]
//[Authorize]
public class CategoryController : Controller
{
    private readonly ICategoryService _categoryService;
    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpPost("AddCategory")]
    public IActionResult AddCategory(AddCategoryDto addCategoryDto)
    {
        try
        {
            var addedCategory = _categoryService.AddCategory(addCategoryDto);
            return Created("/AddCategory", addedCategory);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

}