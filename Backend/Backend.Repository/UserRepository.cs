using Backend.DAL_EF;
using Backend.DataAccessLibrary;
using Backend.Repository.GenericRepositories;
using Backend.Repository.Interfaces;

namespace Backend.Repository;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    private readonly ApplicationDbContext _applicationDbContext;
    public UserRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public User? GetUserByLogin(string login)
    {
        var user = _applicationDbContext.Users.FirstOrDefault(x => x.Login.Equals(login));
        return user;
    }
}