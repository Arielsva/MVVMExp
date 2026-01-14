namespace WebCommerce.App.Configurations
{
    public static class MvcConfig
    {
        public static IServiceCollection AddMvcConfiguration(this IServiceCollection services)
        {
            services.AddRazorPages();

            return services;
        }
    }
}
