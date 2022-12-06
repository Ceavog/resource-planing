using Backend.Services.Interface;
using Backend.Shared.Dtos.CategoryDtos;
using Backend.Shared.Exceptions.CategoryExceptions;
using Backend.Shared.Exceptions.UserExceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Backend.webapi;

[EnableCors("_myAllowSpecificOrigins")]
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
        catch (Exception e) when (e is UserWithGivenIdDoesNotExistsException)
        {
            return NotFound(e.Message);
        }
        catch (Exception e) when (e is CategoryWithGivenNameAndUserWithThisIdAlreadyExistsException)
        {
            return Conflict(e.Message);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("GetAllCategoriesForUserId")]
    public ActionResult<IEnumerable<GetCategoryDto>> GetAllCategoriesForUserId(int userId)
    {
        try
        {
            return Ok(_categoryService.GetAllCategoriesForUserId(userId));
        }
        catch (Exception e) when (e is UserWithGivenIdDoesNotExistsException)
        {
            return NotFound(e.Message);
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }

    [HttpPut("UpdateCategory")]
    public IActionResult UpdateCategory(UpdateCategoryDto categoryDto)
    {
        try
        {
            return Ok(_categoryService.UpdateCategory(categoryDto));
        }
        catch (Exception e) when (e is CategoryWithGivenIdDoesNotExistsException)
        {
            return NotFound(e.Message);
        }
        catch (Exception e) when (e is UserWithGivenIdDoesNotExistsException)
        {
            return NotFound(e.Message);
        }
        catch (Exception e) when (e is CategoryWithGivenNameAndUserWithThisIdAlreadyExistsException)
        {
            return Conflict(e.Message);
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }

    [HttpDelete("DeleteCategoryById")]
    public IActionResult DeleteCategory(int categoryId)
    {
        try
        {
            return Ok(_categoryService.DeleteCategory(categoryId));
        }
        catch (Exception e) when (e is CategoryWithGivenIdDoesNotExistsException)
        {
            return NotFound(e.Message);
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }

}