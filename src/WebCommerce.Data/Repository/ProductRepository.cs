using Microsoft.EntityFrameworkCore;
using WebCommerce.Business.Interfaces;
using WebCommerce.Business.Models;
using WebCommerce.Data.Context;

namespace WebCommerce.Data.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(DataDbContext context) : base(context) { }

        public async Task<Product> GetProductProvider(Guid id)
        {
            return await Db.Products.AsNoTracking()
                .Include(p => p.Provider)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Product>> GetProductsByProvider(Guid providerId)
        {
            return await Search(p=>p.ProviderId == providerId);
        }

        public async Task<IEnumerable<Product>> GetProductsProviders()
        {
            return await Db.Products.AsNoTracking()
                .Include(p => p.Provider)
                .OrderBy(p => p.Name)
                .ToListAsync();
        }
    }
}
