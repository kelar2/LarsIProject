using Microsoft.Identity.Client;
using LarsIProject.WebApi.Repositories;
using LarsIProject.WebApi.Models;
using LarsIProject.WebApi.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.Configure<RouteOptions>(o => o.LowercaseUrls = true);

var sqlConnectionString = builder.Configuration.GetValue<string>("SqlConnectionString");
var sqlConnectionStringFound = !string.IsNullOrWhiteSpace(sqlConnectionString);

if (string.IsNullOrWhiteSpace(sqlConnectionString))
    throw new InvalidProgramException("Configuration variable SqlConnectionString not found");

builder.Services.AddTransient<IObject2DRepository, Object2DRepository>(o => new Object2DRepository(sqlConnectionString));
builder.Services.AddTransient<IEnvironment2DRepository, Environment2DRepository>(o => new Environment2DRepository(sqlConnectionString));

var app = builder.Build();

app.MapGet("/", () => $"The API is up . Connection string found: {(sqlConnectionStringFound ? "yes" : "no")}");

// Configure the HTTP request pipeline.|
app.MapOpenApi();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();