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
    private readonly Logger _logger;
    public ProductsController(IProductService productService)
    {
        _productService = productService;
        _logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();
    }

    [HttpGet("GetAllProductsByUserId")]
    public ActionResult<IEnumerable<ProductDto>> GetAllByUserId(int userId)
    {
        try
        {
            return Ok(Json(_productService.GetAllProductsByUserId(userId)));
        }
        catch (Exception e)
        {
            _logger.Error(e.Message);
            return BadRequest();
        }
    }

    [HttpGet("GetProductId")]
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
            _logger.Error(e.Message);
            return BadRequest();
        }
    }

    [HttpPost("AddProduct")]
    public ActionResult<ProductDto> Add(ProductDto productDto)
    {
        try
        {
            return Ok(Json(_productService.AddProduct(productDto)));
        }
        catch (Exception e)
        {
            _logger.Error(e.Message);
            return BadRequest();
        }
    }

    [HttpPut("UpdateProduct")]
    public ActionResult<ProductDto> Update(ProductDto productDto)
    {
        try
        {
            return Ok(Json(_productService.UpdateProduct(productDto)));
        }
        catch (Exception e)
        {
            _logger.Error(e.Message);
            return BadRequest();
        }
    }

    [HttpDelete("DeleteProduct")]
    public IActionResult Delete(int id)
    {
        try
        {
            
            return Ok(Json(_productService.DeleteProduct(id)));
        }
        catch (Exception e)
        {
            _logger.Error(e.Message);
            return BadRequest();
        }
    }

    [HttpPost("AddManyProducts")]
    public IActionResult AddRange(ICollection<ProductDto> productsDto)
    {
        throw new NotImplementedException();
    }
    
    
}