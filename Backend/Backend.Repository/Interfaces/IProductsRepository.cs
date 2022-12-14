using Backend.DataAccessLibrary;
using Backend.Repository.GenericRepositories;

namespace Backend.Repository.Interfaces;

public interface IProductsRepository : IGenericRepository<Products>
{
    IEnumerable<Products> GetAllProductsByUserId(int id);
    Products UpdateProduct(Products product);
    bool CheckIfProductWithGivenNameAndUserIdAlreadyExists(int userId, string productName);
    bool CheckIfProductWithGivenIdExists(int productId);
    IEnumerable<Products> GetAllProductsByCategoryId(int categoryId);
}