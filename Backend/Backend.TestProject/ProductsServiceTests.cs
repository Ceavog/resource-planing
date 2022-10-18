using Backend.DAL_EF;
using Backend.DataAccessLibrary;
using Backend.Services.Interface;
using Backend.Services.Services;
using Backend.Shared.Dtos.ProductDtos;
using FluentAssertions.Common;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Backend.TestProject;

[TestFixture]
public class ProductsServiceTests
{
    private ApplicationDbContext _applicationDbContext;
    private IProductService _productService;
    
    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        _applicationDbContext = new ApplicationDbContext();
        _productService = new ProductService(_applicationDbContext);
    }

    [Test]
    public void AddProduct_Adds_Product()
    {
        ProductDto productDto = new ProductDto()
        {
            Name = "someName",
            Price = 1.1,
            Section = "section1",
            UserId = 1,
        };
        var product = _productService.AddProduct(productDto);
        Assert.Fail();
        
        
    }
}