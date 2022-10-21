using Backend.DAL_EF;
using Backend.DataAccessLibrary;
using Backend.Repository.GenericRepositories;
using Backend.Repository.Interfaces;

namespace Backend.Repository;

public class RefreshTokenRepository : GenericRepository<RefreshToken>, IRefreshTokenRepository
{
    private readonly ApplicationDbContext _applicationDbContext;
    public RefreshTokenRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public RefreshToken? GetRefreshTokenByUserId(int id)
    {
       return _applicationDbContext.RefreshTokens.FirstOrDefault(x => x.UserId.Equals(id));
    }

    public bool CheckIfUserWithGivenRefreshTokenExists(int userId, string refreshToken)
    {

        return _applicationDbContext.RefreshTokens.Any(
            x => x.UserId.Equals(userId) 
                 && x.Token.Equals(refreshToken) 
                 && x.ExpirationTime > DateTime.Now);
    }

}