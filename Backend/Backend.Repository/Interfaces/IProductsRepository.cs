using Backend.DataAccessLibrary;
using Backend.Repository.GenericRepositories;

namespace Backend.Repository.Interfaces;

public interface IProductsRepository : IGenericRepository<Products>
{
    IEnumerable<Products> GetAllProductsByUserId(int id);
}