using Backend.Services.Interface;
using Backend.Shared.Dtos.ProductDtos;
using Microsoft.AspNetCore.Mvc;

namespace Backend.webapi;

[ApiController]
public class ProductsController : Controller
{
    private readonly IProductService _productService;
    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }
    [HttpGet]
    public ActionResult<IEnumerable<ProductDto>> GetAllByUserId(int userId)
    {
        try
        {
            return Ok(Json(_productService.GetAllProductsByUserId(userId)));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpGet]
    public ActionResult<ProductDto> GetById(int id)
    {
        try
        {
            return Ok(Json(_productService.GetProductById(id)));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    public ActionResult<ProductDto> Add(ProductDto productDto)
    {
        try
        {
            return Ok(Json(_productService.AddProduct(productDto)));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut]
    public ActionResult<ProductDto> Update(ProductDto productDto)
    {
        try
        {
            return Ok(Json(_productService.UpdateProduct(productDto)));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete]
    public IActionResult Delete(int id)
    {
        try
        {
            _productService.DeleteProduct(id);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    public IActionResult AddRange(ICollection<ProductDto> productsDto)
    {
        throw new NotImplementedException();
    }
}