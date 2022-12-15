using Backend.DAL_EF;
using Backend.DataAccessLibrary;
using Backend.Repository;
using Backend.Repository.Interfaces;
using Backend.Repository.Repositories;
using Backend.Services;
using Backend.Services.Interface;
using Backend.Services.Services;
using Backend.Shared.Dtos.ProductDtos;
using Backend.Shared.Exceptions.ProductExceptions;
using Backend.Shared.Exceptions.UserExceptions;
using FluentAssertions;
using FluentAssertions.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Moq;

namespace Backend.TestProject;

[TestFixture]
public class ProductsServiceTests
{
    private IProductsRepository _productsRepository;
    private IUserRepository _userRepository;
    private ProductService _productService;
    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        var dbContextOptionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        dbContextOptionsBuilder.UseInMemoryDatabase("Test");
        var dbContext = new ApplicationDbContext(dbContextOptionsBuilder.Options);

        dbContext.Users.Add(new User
        {
            Id = 1,
            Login = "login1",
            Password = BCrypt.Net.BCrypt.HashPassword("password")
        });

        dbContext.Categories.Add(new Category()
        {
            Id = 1,
            Name = "category1",
            UserId = 1,
        });

        dbContext.Products.Add(new Products()
        {
            Id = 1,
            CategoryId = 1,
            UserId = 1,
            Name = "product1",
            Price = 100.0,
            Section = "section1",
        });
        dbContext.SaveChanges();
        _productsRepository = new ProductsRepository(dbContext);
        _userRepository = new UserRepository(dbContext);
        _productService = new ProductService(_productsRepository, _userRepository);

    }

    [Test]
    public void GetAllProductsByUserId_ShouldThrowExceptionWhenUserDoesNotExists()
    {
        var id = 0;
        Action result = () => _productService.GetAllProductsByUserId(id);
        result.Should().ThrowExactly<UserWithGivenIdDoesNotExistsException>();
    }
}