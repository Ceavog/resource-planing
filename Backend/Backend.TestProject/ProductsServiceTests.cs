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
    // [Test]
    // public void AddProduct_Adds_Product()
    // {
    //    
    //     ProductDto productDto = new ProductDto()
    //     {
    //         Name = "someName",
    //         Price = 1.1,
    //         Section = "section1",
    //         UserId = 1,
    //     };
    //
    //     var repositoryMock = new Mock<IProductService>();
    //     repositoryMock
    //         .Setup(x => x.AddProduct(productDto));
    // }
}