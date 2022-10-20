using Backend.DAL_EF;
using Backend.DataAccessLibrary;
using Backend.Repository.GenericRepositories;
using Backend.Repository.Interfaces;

namespace Backend.Repository;

public class ProductsRepository : GenericRepository<Products>, IProductsRepository
{
    private readonly ApplicationDbContext _applicationDbContext;
    public ProductsRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public IEnumerable<Products> GetAllProductsByUserId(int id)
    {
        return _applicationDbContext.Products.Where(x => x.UserId.Equals(id));
    }
}