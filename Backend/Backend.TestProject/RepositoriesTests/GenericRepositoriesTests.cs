using Backend.DataAccessLibrary;
using Moq;

namespace Backend.TestProject;

public class GenericRepositoriesTests
{
    private readonly Mock<ConnectionFactory> connection = new();
    [SetUp]
    public void Setup()
    {
        
    }
    [Test]
    public void GenericRepository_Add_AddsObjectToDB()
    {
        var genericRepository = new GenericRepository<OrderType>(connection.Object);
        var orderType = new OrderType()
        {
            TypeName = "test type name",
        };
        genericRepository.Add(orderType);
    }
}