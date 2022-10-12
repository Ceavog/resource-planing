using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Backend.DAL_EF;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        //var connectionString = "Server=127.0.0.1; Port=3306; Database=pieczywoDB; Uid=pieczywo;";

        var connectionString = "Server=localhost; Port=3306; Database=pieczywoDB; Uid=root;";
        optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        return new ApplicationDbContext(optionsBuilder.Options);
    }
}