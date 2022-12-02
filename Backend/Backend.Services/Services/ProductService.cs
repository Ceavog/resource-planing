using Backend.DataAccessLibrary;
using Backend.Repository.Interfaces;
using Backend.Services.Interface;
using Backend.Shared.Dtos.ProductDtos;
using Backend.Shared.Exceptions.ProductExceptions;
using Backend.Shared.Exceptions.UserExceptions;
using Mapster;

namespace Backend.Services.Services;

public class ProductService : IProductService
{
    private readonly IProductsRepository _productsRepository;
    private readonly IUserRepository _userRepository;
    public ProductService(IProductsRepository productsRepository, IUserRepository userRepository)
    {
        _productsRepository = productsRepository;
        _userRepository = userRepository;
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
        if (_userRepository.CheckIfUserExists(productDto.UserId))
            throw new UserWithGivenIdDoesNotExistsException(productDto.UserId);
        if (_productsRepository.CheckIfProductWithGivenNameExists(productDto.Name, productDto.UserId))
            throw new ProductWithThisNameAlreadyExistsForThisUserException(productDto.UserId, productDto.Name);
        
        
        return _productsRepository.Add(productDto.Adapt<Products>()).Adapt<AddProductDto>();
    }
    public UpdateProductDto UpdateProduct(UpdateProductDto productDto)
    {
        if (_userRepository.CheckIfUserExists(productDto.UserId))
            throw new UserWithGivenIdDoesNotExistsException(productDto.UserId);
        if (_productsRepository.CheckIfProductWithGivenNameExists(productDto.Name, productDto.UserId))
            throw new ProductWithThisNameAlreadyExistsForThisUserException(productDto.UserId, productDto.Name);
        
        
        return _productsRepository.UpdateProduct(productDto.Adapt<Products>()).Adapt<UpdateProductDto>();
    }
    public ProductDto DeleteProduct(int id)
    {
        return _productsRepository.Delete(id).Adapt<ProductDto>();
    }
}