using Backend.DataAccessLibrary;
using Backend.Shared.Dtos.ProductDtos;

namespace Backend.Services.Interface;

public interface IProductService
{
    Products AddProduct(ProductDto product);
}