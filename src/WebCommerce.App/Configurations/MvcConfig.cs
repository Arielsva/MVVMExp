namespace WebCommerce.App.Configurations
{
    public static class MvcConfig
    {
        public static IServiceCollection AddMvcConfiguration(this IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddRazorPages();

            return services;
        }
    }
}
