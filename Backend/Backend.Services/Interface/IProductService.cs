using Backend.DataAccessLibrary;
using Backend.Shared.Dtos.ProductDtos;

namespace Backend.Services.Interface;

public interface IProductService
{
    IEnumerable<ProductDto> GetAllProductsByUserId(int id);
    ProductDto GetProductById(int id);
    ProductDto AddProduct(ProductDto productDto);
    ProductDto AddRangeProduct(IEnumerable<ProductDto> productsDto);
    ProductDto UpdateProduct(ProductDto productDto);
    void DeleteProduct(int id);
    void Test();





}