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
        
        if (!_userRepository.CheckIfUserWithGivenIdExists(userId))
            throw new UserWithGivenIdDoesNotExistsException(userId);
        
        return _productsRepository.GetAllProductsByUserId(userId).Adapt<IEnumerable<GetProductDto>>();
    }

    public GetProductDto GetProductById(int id)
    {
        if (!_productsRepository.CheckIfProductWithGivenIdExists(id))
            throw new ProductWithGivenIdDoesNotExistsException(id);
        
        return _productsRepository.Get(id)!.Adapt<GetProductDto>();
    }

    public AddProductDto AddProduct(AddProductDto productDto)
    {
        if (!_userRepository.CheckIfUserWithGivenIdExists(productDto.UserId))
            throw new UserWithGivenIdDoesNotExistsException(productDto.UserId);
        if (!_productsRepository.CheckIfProductWithGivenNameAndUserIdAlreadyExists(productDto.UserId, productDto.Name))
            throw new ProductWithThisNameAlreadyExistsForThisUserException(productDto.UserId, productDto.Name);
        
        return _productsRepository.Add(productDto.Adapt<Products>()).Adapt<AddProductDto>();
    }
    public UpdateProductDto UpdateProduct(UpdateProductDto productDto)
    {
        if (!_userRepository.CheckIfUserWithGivenIdExists(productDto.UserId))
            throw new UserWithGivenIdDoesNotExistsException(productDto.UserId);
        if (!_productsRepository.CheckIfProductWithGivenNameAndUserIdAlreadyExists(productDto.UserId, productDto.Name))
            throw new ProductWithThisNameAlreadyExistsForThisUserException(productDto.UserId, productDto.Name);
        
        return _productsRepository.UpdateProduct(productDto.Adapt<Products>()).Adapt<UpdateProductDto>();
    }
    public DeleteProductDto DeleteProduct(int id)
    {
        if (!_productsRepository.CheckIfProductWithGivenIdExists(id))
            throw new ProductWithGivenIdDoesNotExistsException(id);
        return _productsRepository.Delete(id).Adapt<DeleteProductDto>();
    }
}