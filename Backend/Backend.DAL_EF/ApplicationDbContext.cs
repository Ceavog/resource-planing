using Backend.DataAccessLibrary;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.Extensions.Options;
using Pomelo.EntityFrameworkCore.MySql;

namespace Backend.DAL_EF;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
        : base(options)
    {
        
    }
//    public DbSet<Category> Categories { get; set; }
//    public DbSet<Client> Clients { get; set; }
//    public DbSet<Delivery> Deliveries { get; set; }
//    public DbSet<Employee> Employees { get; set; }
    public DbSet<Products> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderPosition> OrderPositions { get; set; }
    public DbSet<OrderType> OrderTypes { get; set; }
//    public DbSet<ServicePoint> ServicePoints { get; set; }
    public DbSet<User> Users { get; set; } 
//    public DbSet<CategoryPositions> CategoryPositions { get; set; }
}