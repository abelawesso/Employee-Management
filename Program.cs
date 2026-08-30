using Employee_API.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.AspNetCore.OpenApi;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowManagement", policy =>
    {
        policy.WithOrigins("https://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseInMemoryDatabase("EmployeeDb");
    options.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()));
    options.EnableSensitiveDataLogging();
});

builder.Services.AddOpenApi();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");


// Configure Scalar API Reference
app.MapOpenApi();
app.MapScalarApiReference(options =>
{
    options.WithTitle("Employee API Documentation");
    options.WithTheme(ScalarTheme.BluePlanet);
    options.WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient);
});

app.UseCors("AllowManagement");
app.UseHttpsRedirection();
app.UseHsts();

await app.RunAsync();


