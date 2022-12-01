using Backend.DataAccessLibrary;
using Backend.Shared.Dtos.ProductDtos;

namespace Backend.Services.Interface;

public interface IProductService
{
    IEnumerable<GetProductDto> GetAllProductsByUserId(int id);
    GetProductDto GetProductById(int id);
    AddProductDto AddProduct(AddProductDto productDto);
    UpdateProductDto UpdateProduct(UpdateProductDto productDto);
    ProductDto DeleteProduct(int id);





}