using Backend.DAL_EF;
using Backend.DataAccessLibrary;
using Backend.Shared.Dtos.ProductDtos;
using Mapster;

namespace Backend.Services.Interface;

public class ProductService : IProductService
{
    private readonly ApplicationDbContext _applicationDbContext;

    public ProductService(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public Products AddProduct(ProductDto product)
    {
        var dbProduct = product.Adapt<Products>();
        dbProduct.User = new User();
        //dbProduct.
        var productEntity =_applicationDbContext.Products.Add(dbProduct);
        _applicationDbContext.SaveChanges();
        return productEntity.Entity;
    }
}