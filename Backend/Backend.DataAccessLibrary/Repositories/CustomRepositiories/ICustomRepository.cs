namespace Backend.DataAccessLibrary.Repositories;

public interface ICustomRepository
{
    IEnumerable<Order> GetOrdersWithPositions(string condition);
}