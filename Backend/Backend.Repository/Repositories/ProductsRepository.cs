using Backend.DAL_EF;
using Backend.DataAccessLibrary;
using Backend.Repository.GenericRepositories;
using Backend.Repository.Interfaces;
using Backend.Shared.Exceptions.ProductExceptions;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository.Repositories;

public class ProductsRepository : GenericRepository<Products>, IProductsRepository
{
    private readonly ApplicationDbContext _applicationDbContext;
    public ProductsRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public IEnumerable<Products> GetAllProductsByUserId(int id)
    {
         return _applicationDbContext.Products.Include(x=>x.Category).Where(x => x.UserId.Equals(id));
    }

    public Products UpdateProduct(Products product)
    {
        _applicationDbContext.ChangeTracker.Clear();
        var updatedProduct = _applicationDbContext.Products.Update(product).Entity;
        _applicationDbContext.Entry(product).Property(x => x.UserId).IsModified = false;
        _applicationDbContext.SaveChanges();
        return updatedProduct;
    }
    /// <summary>
    /// returns true if product with given name exists for user with given id otherwise false
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="productName"></param>
    /// <returns></returns>
    public bool CheckIfProductWithGivenNameAndUserIdAlreadyExists(int userId, string productName)
    {
        return _applicationDbContext.Products.Any(x => x.UserId.Equals(userId) && x.Name.Equals(productName));
    }

    /// <summary>
    /// returns true if product exists otherwise returns false
    /// </summary>
    /// <param name="productId"></param>
    /// <returns></returns>
    public bool CheckIfProductWithGivenIdExists(int productId)
    {
        return _applicationDbContext.Products.Any(x => x.Id.Equals(productId));
    }
    public IEnumerable<Products> GetAllProductsByCategoryId(int categoryId)
    {
        return _applicationDbContext.Products.Where(x => x.CategoryId.Equals(categoryId));
    }

    public Products AddProduct(Products products)
    {
        var addedProduct =_applicationDbContext.Products.Add(products);
        _applicationDbContext.SaveChanges();
        return addedProduct.Entity;
    }
}