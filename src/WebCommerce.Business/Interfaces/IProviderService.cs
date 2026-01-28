using WebCommerce.Business.Models;

namespace WebCommerce.Business.Interfaces
{
    public interface IProviderService : IDisposable
    {
        Task Add(Provider provider);
        Task Update(Provider provider);
        Task Remove(Guid id);
        Task UpdateAddress(Address address);
    }
}
