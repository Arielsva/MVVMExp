using Microsoft.EntityFrameworkCore;
using WebCommerce.Business.Interfaces;
using WebCommerce.Business.Models;
using WebCommerce.Data.Context;

namespace WebCommerce.Data.Repository
{
    public class AddressRepository : Repository<Address>, IAddressRepository
    {
        public AddressRepository(DataDbContext context) : base(context) { }

        public async Task<Address> GetAddressByProvider(Guid providerId)
        {
            return await Db.Addresses.AsNoTracking()
                .FirstOrDefaultAsync(a => a.ProviderId == providerId);
        }
    }
}
