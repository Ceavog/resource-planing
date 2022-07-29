using Backend.DataAccessLibrary;
using NUnit.Framework;
using FluentAssertions;

namespace Backend.TestProject;

public class InfrastructureTests
{
    private IConnectionFactory cf;
    [SetUp]
    public void Setup()
    {
        cf = new ConnectionFactory();
    }

    [Test]
    public void GetConnectionString_ReturnsConnectionString(){
        var coonnectionString = cf.GetConnectionString("some");
        coonnectionString.Should().Be("aa");
    }
}
