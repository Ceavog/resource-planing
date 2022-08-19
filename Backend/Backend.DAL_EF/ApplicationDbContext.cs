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
    /// <summary>
    /// this OnConfiguring is here only for migrations 
    /// </summary>
    /// <param name="optionsBuilder"></param>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = "Server=localhost; Port=6603; Database=et_databaseEF; Uid=root; Pwd=pieczywo;";
        optionsBuilder
            .UseMySql(
                connectionString, 
                ServerVersion.AutoDetect(connectionString), 
                x=>x.MigrationsAssembly("Backend.DAL_EF"));
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Delivery> Deliveries { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<MenuPosition> MenuPositions { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderPosition> OrderPositions { get; set; }
    public DbSet<OrderType> OrderTypes { get; set; }
    public DbSet<ServicePoint> ServicePoints { get; set; }
    public DbSet<User> Users { get; set; }
}