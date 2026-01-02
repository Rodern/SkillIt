using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace SkillIT_Models.Data
{
    /// <summary>
    /// Design-time factory for ApplicationDbContext
    /// Used by EF Core tools to create migrations
    /// </summary>
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            
            // Use a placeholder connection string for migrations
            // ServerVersion is hard-coded to avoid connecting to database during design-time
            var connectionString = "Server=localhost;Database=skillit;User=root;";
            
            optionsBuilder.UseMySql(
                connectionString,
                new MySqlServerVersion(new Version(8, 0, 33)),
                mySqlOptions =>
                {
                    mySqlOptions.MigrationsAssembly("SkillIT-Models");
                });

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
