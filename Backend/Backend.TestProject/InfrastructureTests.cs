using Backend.DataAccessLibrary;
using NUnit.Framework;
using FluentAssertions;
using System.Data;
using Backend.Services.Interface;
using Moq;

namespace Backend.TestProject;

public class InfrastructureTests
{
    private readonly Mock<IOrderTypesService> _orderTypesService = new();
    private object x;    
    [SetUp]
    public void Setup()
    {
        
    }
    // [Test]
    // public void AddTest_test()
    // {
    //
    //     OrderTypesRepository otr = new OrderTypesRepository(_connectionFactory.Object);
    //     otr.AddTest();
    // }
}