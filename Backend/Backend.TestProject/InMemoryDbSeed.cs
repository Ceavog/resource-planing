using Backend.DAL_EF;
using Backend.DataAccessLibrary;
using Microsoft.EntityFrameworkCore;

namespace Backend.TestProject;

public static class InMemoryDbSeed
{
    public static ApplicationDbContext SeedDbContext()
    {
        var dbContextOptionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        dbContextOptionsBuilder.UseInMemoryDatabase("Test");
        var dbContext = new ApplicationDbContext(dbContextOptionsBuilder.Options);

        dbContext.Users.Add(new User
        {
            Id = 1,
            Login = "login1",
            Password = BCrypt.Net.BCrypt.HashPassword("password")
        });

        dbContext.Categories.Add(new Category()
        {
            Id = 1,
            Name = "category1",
            UserId = 1,
        });

        dbContext.Products.Add(new Products()
        {
            Id = 1,
            CategoryId = 1,
            UserId = 1,
            Name = "product1",
            Price = 100.0,
            Section = "section1",
        });
        dbContext.SaveChanges();

        return dbContext;
    }
}