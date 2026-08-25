using Employee_API.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;


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

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.UseCors("AllowManagement");
app.UseHttpsRedirection();
app.UseHsts();

await app.RunAsync();


