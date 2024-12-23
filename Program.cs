using System.Data.Common;
using AdventureLog_API.Database;
using AdventureLog_API.Models;
using AdventureLog_API.Repositories;
using AdventureLog_API.Services;
using Microsoft.EntityFrameworkCore;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// TODO: Abract to neater function down the line
var configManager = builder.Configuration;
var config = new ApplicationConfig();
configManager.Bind("Application", config);
builder.Services.AddSingleton<ApplicationConfig>(provider => config);
// builder.Services.AddScoped<ApplicationContext>();

builder.Services.AddScoped<DbConnection>(_ => new NpgsqlConnection(
    config.ConnectionString
));

builder.Services.AddDbContext<ApplicationContext>();
builder.Services.AddScoped(typeof(IEfCoreService), typeof(EfCoreService));
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

/** TODOs:
- gitignore
- Service
- Repository
- ApplicationContext
- ApplicationConfig
*/