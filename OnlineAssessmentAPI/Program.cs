using Microsoft.EntityFrameworkCore;
using OnlineAssessmentAPI.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AssessmentDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add controllers support
builder.Services.AddControllers();

// Add OpenAPI/Swagger support
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Map API controllers
app.MapControllers();

app.Run();