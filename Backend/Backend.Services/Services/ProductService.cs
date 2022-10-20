using Backend.DAL_EF;
using Backend.DataAccessLibrary;
using Backend.Repository;
using Backend.Repository.Interfaces;
using Backend.Shared.Dtos.ProductDtos;
using Mapster;

namespace Backend.Services.Interface;

public class ProductService : IProductService
{
    private readonly ApplicationDbContext _applicationDbContext;
    private readonly IProductsRepository _productsRepository;
    public ProductService(ApplicationDbContext applicationDbContext, IProductsRepository productsRepository)
    {
        _applicationDbContext = applicationDbContext;
        _productsRepository = productsRepository;
    }

    public IEnumerable<ProductDto> GetAllProductsByUserId(int userId)
    {
        var productsEntities = _applicationDbContext.Products.Where(x=>x.UserId.Equals(userId));
        return productsEntities.Adapt<IEnumerable<ProductDto>>();
    }

    public ProductDto GetProductById(int id)
    {
        var productEntity = _applicationDbContext.Products.Find(id);
        return productEntity.Adapt<ProductDto>();
    }

    public ProductDto AddProduct(ProductDto productDto)
    {
        var dbProduct = productDto.Adapt<Products>();
        var productEntity =_applicationDbContext.Products.Add(dbProduct);
        _applicationDbContext.SaveChanges();
        return productEntity.Entity.Adapt<ProductDto>();
    }

    public ProductDto AddRangeProduct(IEnumerable<ProductDto> productsDto)
    {
        throw new NotImplementedException();
    }

    public ProductDto UpdateProduct(ProductDto productDto)
    {
        var dbProduct = productDto.Adapt<Products>();
        var updatedProduct = _applicationDbContext.Products.Update(dbProduct);
        _applicationDbContext.SaveChanges();
        return updatedProduct.Adapt<ProductDto>(); 

    }
    public void DeleteProduct(int id)
    {
        _applicationDbContext.Products.Remove(_applicationDbContext.Products.Find(id) ?? throw new InvalidOperationException());
        _applicationDbContext.SaveChanges();
    }

    public void Test()
    {
        _productsRepository.Test();
    }
}