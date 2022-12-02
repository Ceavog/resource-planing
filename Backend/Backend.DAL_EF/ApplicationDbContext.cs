using Backend.DataAccessLibrary;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.Extensions.Options;
using Pomelo.EntityFrameworkCore.MySql;

namespace Backend.DAL_EF;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
        
    }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
        : base(options)
    {
        
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        try
        {
            var connectionString = "Server=db; Port=3306; Database=pieczywoDB; Uid=root;";
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
        catch (Exception e)
        {
            var connectionString = "Server=localhost; Port=3306; Database=pieczywoDB; Uid=root;";
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

    }
//    public DbSet<Client> Clients { get; set; }
//    public DbSet<Delivery> Deliveries { get; set; }
//    public DbSet<ServicePoint> ServicePoints { get; set; }
//    public DbSet<Employee> Employees { get; set; }
    public virtual DbSet<Products> Products { get; set; }
    public virtual DbSet<Order> Orders { get; set; }
    public virtual DbSet<OrderPosition> OrderPositions { get; set; }
    public virtual DbSet<OrderType> OrderTypes { get; set; }
    public virtual DbSet<Category> Categories { get; set; }
    public virtual DbSet<CategoryPositions> CategoryPositions { get; set; }

    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<RefreshToken> RefreshTokens { get; set; }
}