using System.Diagnostics;
using Backend.Services.Interface;
using Backend.Shared.Dtos.ProductDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Serilog.Core;

namespace Backend.webapi;

[ApiController]
//[Authorize]
public class ProductsController : Controller
{
    private readonly IProductService _productService;
    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet("GetAllProductsByUserId")]
    public ActionResult<IEnumerable<ProductDto>> GetAllProtuctsByUserId(int userId)
    {
        try
        {
            return Ok(Json(_productService.GetAllProductsByUserId(userId)));
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }

    [HttpGet("GetProductById")]
    public ActionResult<ProductDto> GetProductById(int id)
    {
        try
        {
            var product = _productService.GetProductById(id);
            if (product is null)
                return NotFound();

            return Ok(Json(product));
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }

    [HttpPost("AddProduct")]
    public ActionResult<ProductDto> AddProduct(ProductDto productDto)
    {
        try
        {
            var addedProduct = _productService.AddProduct(productDto);
            return Created("/AddProduct",Json(addedProduct));
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }

    [HttpPut("UpdateProduct")]
    public ActionResult<ProductDto> UpdateProduct(ProductDto productDto)
    {
        try
        {
            var updatedProduct = _productService.UpdateProduct(productDto);
            return Ok(Json(updatedProduct));
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }

    [HttpDelete("DeleteProductById")]
    public IActionResult DeleteProduct(int id)
    {
        try
        {
            var deletedProduct = _productService.DeleteProduct(id);
            return Ok(Json(deletedProduct));
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }

    [HttpPost("AddManyProducts")]
    public IActionResult AddRange(ICollection<ProductDto> productsDto)
    {
        throw new NotImplementedException();
    }
    
    
}