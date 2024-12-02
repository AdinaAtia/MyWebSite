using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Repositories;
using Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddControllers();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserServices, UserService>();
//options Builder.UseSqlServer("Server=SRV2\\PUPILS;Database=Catagory;Trusted_Connection=True;TrustServerCertificate=True")
builder.Services.AddDbContext<CatagoryContext>(options => options.UseSqlServer("Server=SRV2\\PUPILS;Database=Catagory;Trusted_Connection=True;TrustServerCertificate=True"));
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
