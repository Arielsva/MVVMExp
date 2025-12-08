using Microsoft.EntityFrameworkCore;
using WebCommerce.Business.Interfaces;
using WebCommerce.Business.Models;
using WebCommerce.Data.Context;

namespace WebCommerce.Data.Repository
{
    public class ProviderRepository : Repository<Provider>, IProviderRepository
    {
        public ProviderRepository(DataDbContext context) : base(context) { }

        public async Task<Provider> GetProviderAddress(Guid id)
        {
            return await Db.Providers.AsNoTracking()
                .Include(a => a.Address)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Provider> GetProviderProductsAddress(Guid id)
        {
            return await Db.Providers.AsNoTracking()
                .Include(p => p.Products)
                .Include(a => a.Address)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
