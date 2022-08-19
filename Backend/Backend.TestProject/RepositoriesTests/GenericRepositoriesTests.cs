// using System.Data;
// using System.Data.Common;
// using Backend.DataAccessLibrary;
// using Backend.DataAccessLibrary.Configuration;
// using Backend.DataAccessLibrary.UnitOfWork;
// using Backend.Services.Services;
// using FluentAssertions;
// using Moq;
//
// namespace Backend.TestProject;
//
// public class GenericRepositoriesTests
// {
//
//     private Mock<UnitOfWork> _unitOfWork;
//     [SetUp]
//     public void Setup()
//     {
//         var _connectionFactory = new Mock<ConnectionFactory>().Object;
//         var _configuration = new Mock<IConfiguration>().Object;
//         _unitOfWork = new Mock<UnitOfWork>(_connectionFactory, _configuration);
//     }
//     [Test]
//     public void GenericRepository_Add_AddsObjectToDB()
//     {
//         
//         var orderType = new OrderType()
//         {
//             TypeName = "test type name",
//         };
//
//         var service = new OrderPositionsService(_unitOfWork.Object);
//         var count = service.GetAllOrderPositionsByOrderId();
//         count.Should().HaveCount(15);
//     }
//
//     [Test]
//     public void CustomRepository_method_ReturnsCorrectValue()
//     {
//         var service = new OrderService(_unitOfWork.Object);
//         var count = service.GetAllOrdersWithOrderPositions();
//         count.Should().HaveCount(12);
//     }
// }