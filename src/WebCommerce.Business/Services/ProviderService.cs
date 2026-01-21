using WebCommerce.Business.Interfaces;
using WebCommerce.Business.Models;
using WebCommerce.Business.Models.Validations;

namespace WebCommerce.Business.Services
{
    public class ProviderService : BaseService, IProviderService
    {
        private readonly IProviderRepository _providerRepository;
        private readonly IAddressRepository _addressRepository;

        public ProviderService(IProviderRepository providerRepository,
            IAddressRepository addressRepository,INotifier notifier) : base(notifier)
        {
            _providerRepository = providerRepository;
            _addressRepository = addressRepository;
        }

        public async Task Add(Provider provider)
        {
            if (!ExecuteValidation(new ProviderValidation(), provider)
                || !ExecuteValidation(new AddressValidation(), provider.Address)) return;

            if(_providerRepository.Search(p => p.Document == provider.Document).Result.Any())
            {
                Notify("A provider already exists with the specified document.");
                return;
            }

            await _providerRepository.Add(provider);
        }

        public async Task Update(Provider provider)
        {
            if (!ExecuteValidation(new ProviderValidation(), provider)) return;

            if (_providerRepository.Search(p => p.Document == provider.Document && p.Id != provider.Id).Result.Any())
            {
                Notify("A provider already exists with the specified document.");
                return;
            }

            await _providerRepository.Update(provider);
        }

        public async Task UpdateAddress(Address address)
        {
            if (ExecuteValidation(new AddressValidation(), address)) return;

            await _addressRepository.Update(address);
        }

        public async Task Remove(Guid id)
        {
            if (_providerRepository.GetProviderProductsAddress(id).Result.Products.Any())
            {
                Notify("The supplier has items registered.");
                return;
            }

            await _providerRepository.Remove(id);
        }

        public void Dispose()
        {
            _providerRepository?.Dispose();
            _addressRepository?.Dispose();
        }
    }
}