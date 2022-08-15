namespace Backend.DataAccessLibrary.Repositories;

public class CustomRepository : ICustomRepository
{
    private readonly IConnectionFactory _connectionFactory;
    public CustomRepository(IConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }
}