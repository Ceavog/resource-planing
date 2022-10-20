using Backend.DataAccessLibrary;
using Backend.Shared.Dtos.ProductDtos;

namespace Backend.Services.Interface;

public interface IProductService
{
    IEnumerable<ProductDto> GetAllProductsByUserId(int id);
    ProductDto GetProductById(int id);
    ProductDto AddProduct(ProductDto productDto);
    ProductDto UpdateProduct(ProductDto productDto);
    ProductDto DeleteProduct(int id);





}