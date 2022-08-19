using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Backend.DAL_EF;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        var connectionString = "Server=localhost; Port=6603; Database=et_databaseEF; Uid=root; Pwd=pieczywo;";
        optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        return new ApplicationDbContext(optionsBuilder.Options);
    }
}