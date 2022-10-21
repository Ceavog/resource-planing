using Backend.DAL_EF;
using Backend.DataAccessLibrary;
using Backend.Repository;
using Backend.Services;
using Backend.Services.Interface;
using Backend.Services.Services;
using Backend.Shared.Dtos.ProductDtos;
using FluentAssertions;
using FluentAssertions.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Moq;

namespace Backend.TestProject;

[TestFixture]
public class ProductsServiceTests
{
    private ProductService _ProductService;
    private ApplicationDbContext _applicationDbContext;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        _applicationDbContext = new ApplicationDbContext();
        var productRepo = new ProductsRepository(_applicationDbContext);
        _ProductService = new ProductService(productRepo);
    }

    [Test]
    public void GetAllProductsByUserId_ShouldThrowExceptionWhenUserDoesNotExists()
    {
        var id = Int32.MaxValue;

        Action result = () =>_ProductService.GetAllProductsByUserId(id);

        result.Should().ThrowExactly<ArgumentException>().WithMessage("User with this id does not exists");
    }
}