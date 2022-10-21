using Backend.DAL_EF;
using Backend.DataAccessLibrary;
using Backend.Repository;
using Backend.Repository.Interfaces;
using Backend.Shared.Dtos.ProductDtos;
using Mapster;

namespace Backend.Services.Interface;

public class ProductService : IProductService
{
    private readonly IProductsRepository _productsRepository;
    public ProductService(IProductsRepository productsRepository)
    {
        _productsRepository = productsRepository;
    }

    public IEnumerable<ProductDto> GetAllProductsByUserId(int userId)
    {
        return _productsRepository.GetAllProductsByUserId(userId).Adapt<IEnumerable<ProductDto>>();
    }

    public ProductDto GetProductById(int id)
    {
        return _productsRepository.Get(id)!.Adapt<ProductDto>();
    }

    public ProductDto AddProduct(ProductDto productDto)
    {
        return _productsRepository.Add(productDto.Adapt<Products>()).Adapt<ProductDto>();
    }
    public ProductDto UpdateProduct(ProductDto productDto)
    {
        return _productsRepository.Update(productDto.Adapt<Products>()).Adapt<ProductDto>();
    }
    public ProductDto DeleteProduct(int id)
    {
        return _productsRepository.Delete(id).Adapt<ProductDto>();
    }
}