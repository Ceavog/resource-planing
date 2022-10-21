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
        if (_applicationDbContext.Users.Any(x => x.Id.Equals(id))) {
            return _applicationDbContext.Products.Where(x => x.UserId.Equals(id));
        }
        throw new ArgumentException("User With This Id Does not exists");
    }
}