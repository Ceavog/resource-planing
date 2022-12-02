using Backend.DAL_EF;
using Backend.DataAccessLibrary;
using Backend.Repository.GenericRepositories;
using Backend.Repository.Interfaces;
using Backend.Shared.Exceptions.ProductExceptions;

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
        if (_applicationDbContext.Users.Any(x => x.Id.Equals(id))) {
            return _applicationDbContext.Products.Where(x => x.UserId.Equals(id));
        }
        throw new ArgumentException("User With This Id Does not exists");
    }

    public Products UpdateProduct(Products product)
    {
        _applicationDbContext.ChangeTracker.Clear();
        var updatedProduct = _applicationDbContext.Products.Update(product).Entity;
        _applicationDbContext.Entry(product).Property(x => x.UserId).IsModified = false;
        _applicationDbContext.SaveChanges();
        return updatedProduct;
    }
    public void ThrowExceptionWhenProductWithGivenNameAndUserIdAlreadyExists(int userId, string name)
    {
        if (_applicationDbContext.Products.Any(x => x.UserId.Equals(userId) && x.Name.Equals(name)))
            throw new ProductWithThisNameAlreadyExistsForThisUserException(userId, name);
    }
    public void ThrowExceptionWhenProductWithGivenIdDoesNotExists(int productId)
    {
        if (!_applicationDbContext.Products.Any(x => x.Id.Equals(productId)))
            throw new ProductWithGivenIdDoesNotExistsException(productId);
    }

    public Products AddProduct(Products products)
    {
        var addedProduct =_applicationDbContext.Products.Add(products);
        _applicationDbContext.SaveChanges();
        return addedProduct.Entity;
    }
}