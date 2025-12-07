using Microsoft.EntityFrameworkCore;
using WebCommerce.Data.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataDbContext>(o =>
    o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

app.Run();
