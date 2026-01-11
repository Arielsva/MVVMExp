using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using WebCommerce.App.Data;
using WebCommerce.App.Extensions;
using WebCommerce.Business.Interfaces;
using WebCommerce.Data.Context;
using WebCommerce.Data.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(o =>
    o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDbContext<DataDbContext>(o =>
    o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped<DataDbContext>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProviderRepository, ProviderRepository>();
builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddSingleton<IValidationAttributeAdapterProvider, CurrencyValidationAttributeAdapterProvider>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

var defaultCulture = new CultureInfo("en-US");
var localizationOptions = new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture(defaultCulture),
    SupportedCultures = new List<CultureInfo> { defaultCulture },
    SupportedUICultures = new List<CultureInfo> { defaultCulture }
};

app.UseRequestLocalization(localizationOptions);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
