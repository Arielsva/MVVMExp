using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared;
using WebCommerce.App.ViewModels;
using WebCommerce.Business.Interfaces;
using WebCommerce.Business.Models;

namespace WebCommerce.App.Controllers
{
    public class ProvidersController : BaseController
    {
        private readonly IProviderRepository _providerRepository;
        private readonly IProviderService _providerService;
        private readonly IMapper _mapper;

        public ProvidersController(IProviderRepository providerRepository,
                                   IProviderService providerService,
                                   IMapper mapper,
                                   INotifier notifier) : base(notifier)
        {
            _providerRepository = providerRepository;
            _mapper = mapper;
            _providerService = providerService;
        }

        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<ProviderViewModel>>(await _providerRepository.GetAll()));
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var providerViewModel = await GetProviderAddress(id);

            if (providerViewModel == null) return NotFound();

            return View(providerViewModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProviderViewModel providerViewModel)
        {
            if (!ModelState.IsValid) return View(providerViewModel);

            var provider = _mapper.Map<Provider>(providerViewModel);
            await _providerService.Add(provider);

            if (!ValidOperation()) return View(providerViewModel);

            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> Edit(Guid id)
        {
            var providerViewModel = await GetProviderProductsAddress(id);

            if (providerViewModel == null) return NotFound();

            return View(providerViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Guid id, ProviderViewModel providerViewModel)
        {
            if (id != providerViewModel.Id) return NotFound();

            if (!ModelState.IsValid) return View(providerViewModel);

            var provider = _mapper.Map<Provider>(providerViewModel);
            await _providerService.Update(provider);

            if (!ValidOperation()) return View(await GetProviderProductsAddress(id));

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var providerViewModel = await GetProviderAddress(id);

            if (providerViewModel == null) return NotFound();

            return View(providerViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var providerViewModel = await GetProviderAddress(id);

            if (providerViewModel == null) return NotFound();

            await _providerService.Remove(id);

            if (!ValidOperation()) return View(providerViewModel);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> GetAddress(Guid id)
        {
            var provider = await GetProviderAddress(id);

            if (provider == null) return NotFound();

            return PartialView("_AddressDetails", provider);
        }

        public async Task<IActionResult> UpdateAddress(Guid id)
        {
            var provider = await GetProviderAddress(id);

            if (provider == null) return NotFound();

            return PartialView("_AddressUpdate", new ProviderViewModel { Address = provider.Address});
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateAddress(ProviderViewModel providerViewModel)
        {
            ModelState.Remove("Name");
            ModelState.Remove("Document");

            if (!ModelState.IsValid) return PartialView("_AddressUpdate", providerViewModel);

            await _providerService.UpdateAddress(_mapper.Map<Address>(providerViewModel.Address));

            if (!ValidOperation()) return PartialView("_AddressUpdate", providerViewModel);

            var url = Url.Action("GetAddress", "Providers", new { id = providerViewModel.Address.ProviderId });

            return Json(new { success = true, url });
        }

        private async Task<ProviderViewModel> GetProviderAddress(Guid id)
        {
            return _mapper.Map<ProviderViewModel>(await _providerRepository.GetProviderAddress(id));
        }

        private async Task<ProviderViewModel> GetProviderProductsAddress(Guid id)
        {
            return _mapper.Map<ProviderViewModel>(await _providerRepository.GetProviderProductsAddress(id));
        }
    }
}
