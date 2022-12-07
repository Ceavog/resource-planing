using Backend.DataAccessLibrary;
using Backend.Repository.GenericRepositories;

namespace Backend.Repository.Interfaces;

public interface IProductsRepository : IGenericRepository<Products>
{
    IEnumerable<Products> GetAllProductsByUserId(int id);
    Products UpdateProduct(Products product);
    void ThrowExceptionWhenProductWithGivenNameAndUserIdAlreadyExists(int userId, string name);
    void ThrowExceptionWhenProductWithGivenIdDoesNotExists(int productId);
    IEnumerable<Products> GetAllProductsByCategoryId(int categoryId);
}