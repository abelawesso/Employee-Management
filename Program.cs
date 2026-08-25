var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowManagement", policy =>
    {
        policy.WithOrigins("https://localhost:5001")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

app.UseCors("AllowManagement");
app.UseHttpsRedirection();
app.UseHsts();

await app.RunAsync();


