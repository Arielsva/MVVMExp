using Microsoft.AspNetCore.Mvc.DataAnnotations;
using WebCommerce.App.Extensions;
using WebCommerce.Business.Interfaces;
using WebCommerce.Data.Context;
using WebCommerce.Data.Repository;

namespace WebCommerce.App.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<DataDbContext>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProviderRepository, ProviderRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddSingleton<IValidationAttributeAdapterProvider, CurrencyValidationAttributeAdapterProvider>();

            return services;
        }
    }
}
