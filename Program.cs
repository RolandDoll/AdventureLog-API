using AdventureLog_API.Models;

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