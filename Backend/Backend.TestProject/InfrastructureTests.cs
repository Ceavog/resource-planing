using Backend.DataAccessLibrary;
using NUnit.Framework;
using FluentAssertions;
using System.Data;
using Backend.DataAccessLibrary.Configuration;
using Moq;

namespace Backend.TestProject;

public class InfrastructureTests
{
    private readonly Mock<ConnectionFactory> _connectionFactory = new();
    private object x;    
    [SetUp]
    public void Setup()
    {
        
    }
    [Test]
    public void AddTest_test()
    {

        OrderTypesRepository otr = new OrderTypesRepository(_connectionFactory.Object);
        otr.AddTest();
    }
}