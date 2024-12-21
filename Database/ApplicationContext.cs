using AdventureLog_API.Models;
using Microsoft.EntityFrameworkCore;

namespace AdventureLog_API.Database;

public class ApplicationContext : DbContext
{
    private readonly ApplicationConfig _applicationConfig;
    private string _connectionString => _applicationConfig.ConnectionString;
    public DbSet<User> Users { get; set; }

    public ApplicationContext(
        ApplicationConfig applicationConfig,
        DbContextOptions options
    )
    : base(options)
    {
        _applicationConfig = applicationConfig;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_connectionString)
            .EnableSensitiveDataLogging()
            .UseSnakeCaseNamingConvention();
    }
}