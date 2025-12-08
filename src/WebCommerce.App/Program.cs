using Microsoft.EntityFrameworkCore;
using WebCommerce.Business.Interfaces;
using WebCommerce.Data.Context;
using WebCommerce.Data.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataDbContext>(o =>
    o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<DataDbContext>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProviderRepository, ProviderRepository>();
builder.Services.AddScoped<IAddressRepository, AddressRepository>();

var app = builder.Build();

app.Run();
