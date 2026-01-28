using Microsoft.AspNetCore.Mvc;
using WebCommerce.Business.Interfaces;

namespace WebCommerce.App.Controllers
{
    public abstract class BaseController : Controller
    {
        private readonly INotifier _notifier;

        protected BaseController(INotifier notifier)
        {
            _notifier = notifier;
        }

        protected bool ValidOperation()
        {
            return !_notifier.HasNotification();
        }
    }
}
