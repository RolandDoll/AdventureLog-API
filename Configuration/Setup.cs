using System.Data.Common;
using AdventureLog_API.Database;
using AdventureLog_API.Models;
using AdventureLog_API.Repositories;
using AdventureLog_API.Services;
using Npgsql;

namespace AdventureLog_API.Configuration;

public static class Setup
{
    public static void Configure(this WebApplicationBuilder builder)
    {
        SetupConfiguration(builder);
        SetupServices(builder);
        SetupRepositories(builder);
    }

    private static void SetupConfiguration(WebApplicationBuilder builder)
    {
        var configManager = builder.Configuration;
        var config = new ApplicationConfig();
        configManager.Bind("Application", config);
        builder.Services.AddSingleton(provider => config);

        builder.Services.AddScoped<DbConnection>(_ => new NpgsqlConnection(
            config.ConnectionString
        ));

        builder.Services.AddDbContext<ApplicationContext>();
    }
    
    private static void SetupServices(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped(typeof(IEfCoreService), typeof(EfCoreService));
        builder.Services.AddScoped<IUserService, UserService>();
    }

    private static void SetupRepositories(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IUserRepository, UserRepository>();
    }
}