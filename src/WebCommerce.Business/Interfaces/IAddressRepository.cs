using WebCommerce.Business.Models;

namespace WebCommerce.Business.Interfaces
{
    public interface IAddressRepository : IRepository<Address>
    {
        Task<Address> GetAddressByProvider(Guid providerId);
    }
}
