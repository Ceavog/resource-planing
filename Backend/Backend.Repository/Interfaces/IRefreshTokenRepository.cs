using Backend.DataAccessLibrary;
using Backend.Repository.GenericRepositories;

namespace Backend.Repository.Interfaces;

public interface IRefreshTokenRepository : IGenericRepository<RefreshToken>
{
    RefreshToken? GetRefreshTokenByUserId(int id);
    bool CheckIfUserWithGivenRefreshTokenExists(int userId, string refreshToken);
}