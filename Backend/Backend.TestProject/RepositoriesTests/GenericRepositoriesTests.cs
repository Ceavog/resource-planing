using System.Data;
using System.Data.Common;
using Backend.DataAccessLibrary;
using Backend.DataAccessLibrary.UnitOfWork;
using Backend.Services.Services;
using Moq;

namespace Backend.TestProject;

public class GenericRepositoriesTests
{

    private Mock<UnitOfWork<OrderType>> _unitOfWork;
    [SetUp]
    public void Setup()
    {
        var _connectionFactory = new Mock<ConnectionFactory>();
        var _dbTransaction = _connectionFactory.Object.GetConnection.BeginTransaction();
        _unitOfWork = new Mock<UnitOfWork<OrderType>>(_dbTransaction);
    }
    [Test]
    public void GenericRepository_Add_AddsObjectToDB()
    {
        
        var orderType = new OrderType()
        {
            TypeName = "test type name",
        };

        var service = new OrderTypesService(_unitOfWork.Object);
        service.AddType(orderType);
    }
}