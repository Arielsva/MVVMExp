using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebCommerce.App.ViewModels;


namespace WebCommerce.App.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }
        public DbSet<WebCommerce.App.ViewModels.ProductViewModel> ProductViewModel { get; set; } = default!;
    }
}
