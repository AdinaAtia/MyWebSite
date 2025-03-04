//using Microsoft.AspNetCore.Builder;
//using MyShop;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Options;
//using Repositories;
//using Services;
//using NLog.Web;


////using DotNetEnv;

//var builder = WebApplication.CreateBuilder(args);


////Env.Load();
//// Add services to the container.

////builder.Services.AddControllers();
////builder.Services.AddControllers();
//builder.Host.UseNLog();

//builder.Services.AddTransient<IUserRepository, UserRepository>();
//builder.Services.AddTransient<IUserServices, UserService>();
//builder.Services.AddTransient<IProductsRepository, ProductsRepository>();
//builder.Services.AddTransient<IProductsServices, ProductsServices>();
//builder.Services.AddTransient<ICategoryServices, CategoryServices>();
//builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
//builder.Services.AddTransient<IOrderServices, OrderServices>();
//builder.Services.AddTransient<IOrderRepositories, OrderRepositories>();
//builder.Services.AddTransient<IRatingService, RatingService>();
//builder.Services.AddTransient<IRatingRepository, RatingRepository>();
////options Builder.UseSqlServer("Server=SRV2\\PUPILS;Database=Catagory;Trusted_Connection=True;TrustServerCertificate=True")
////builder.Services.AddDbContext<CatagoryContext>(options => options.UseSqlServer(Environment.GetEnvironmentVariable("connectionString")));
//builder.Services.AddDbContext<CatagoryContext>(options => options.UseSqlServer("Server=SRV2\\PUPILS;Database=Catagory;Trusted_Connection=True;TrustServerCertificate=True"));


//builder.Services.AddControllers();
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
//var app = builder.Build();
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}
//// Configure the HTTP request pipeline.
//app.UseHttpsRedirection();
//app.UseStaticFiles();
//app.UseAuthorization();
//app.UseMiddlewareRating();

//app.MapControllers();
//app.Run();


//using Microsoft.AspNetCore.Builder;
//using MyShop;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Options;
//using Repositories;
//using Services;
//using NLog.Web;

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//builder.Host.UseNLog();

//builder.Services.AddTransient<IUserRepository, UserRepository>();
//builder.Services.AddTransient<IUserServices, UserService>();
//builder.Services.AddTransient<IProductsRepository, ProductsRepository>();
//builder.Services.AddTransient<IProductsServices, ProductsServices>();
//builder.Services.AddTransient<ICategoryServices, CategoryServices>();
//builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
//builder.Services.AddTransient<IOrderServices, OrderServices>();
//builder.Services.AddTransient<IOrderRepositories, OrderRepositories>();
//builder.Services.AddTransient<IRatingService, RatingService>();
//builder.Services.AddTransient<IRatingRepository, RatingRepository>();

//// Register CatagoryContext with IDbContextFactory
//builder.Services.AddDbContextFactory<CatagoryContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("CatagoryContext")));

//builder.Services.AddControllers();
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//var app = builder.Build();

//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//// Configure the HTTP request pipeline.
//app.UseHttpsRedirection();
//app.UseStaticFiles();
//app.UseAuthorization();
//app.UseMiddlewareRating();

//app.MapControllers();
//app.Run();





using Microsoft.AspNetCore.Builder;
using MyShop;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Repositories;
using Services;
using NLog.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Host.UseNLog();

builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IUserServices, UserService>();
builder.Services.AddTransient<IProductsRepository, ProductsRepository>();
builder.Services.AddTransient<IProductsServices, ProductsServices>();
builder.Services.AddTransient<ICategoryServices, CategoryServices>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<IOrderServices, OrderServices>();
builder.Services.AddTransient<IOrderRepositories, OrderRepositories>();
builder.Services.AddTransient<IRatingService, RatingService>();
builder.Services.AddTransient<IRatingRepository, RatingRepository>();

// Register CatagoryContext with IDbContextFactory
builder.Services.AddDbContextFactory<CatagoryContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CatagoryContext"), sqlOptions =>
        sqlOptions.EnableRetryOnFailure())); // Adding EnableRetryOnFailure

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();
app.UseMiddlewareRating();

app.MapControllers();
app.Run();