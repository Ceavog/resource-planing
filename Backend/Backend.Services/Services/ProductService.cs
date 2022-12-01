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

    public IEnumerable<GetProductDto> GetAllProductsByUserId(int userId)
    {
        return _productsRepository.GetAllProductsByUserId(userId).Adapt<IEnumerable<GetProductDto>>();
    }

    public GetProductDto GetProductById(int id)
    {
        return _productsRepository.Get(id)!.Adapt<GetProductDto>();
    }

    public AddProductDto AddProduct(AddProductDto productDto)
    {
        return _productsRepository.Add(productDto.Adapt<Products>()).Adapt<AddProductDto>();
    }
    public UpdateProductDto UpdateProduct(UpdateProductDto productDto)
    {
        return _productsRepository.Update(productDto.Adapt<Products>()).Adapt<UpdateProductDto>();
    }
    public ProductDto DeleteProduct(int id)
    {
        return _productsRepository.Delete(id).Adapt<ProductDto>();
    }
}