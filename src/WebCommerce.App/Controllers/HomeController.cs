using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebCommerce.App.ViewModels;

namespace WebCommerce.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Route("error/{id:length(3,3)}")]
        public IActionResult Errors(int id)
        {
            var modelErro = new ErrorViewModel();

            if (id == 500)
            {
                modelErro.Message = "An error occurred! Please try again later or contact our support team.";
                modelErro.Title = "An error occurred!";
                modelErro.ErrorCode = id;
            }
            else if (id == 404)
            {
                modelErro.Message = "The page you are looking for does not exist! <br />If you have any questions, please contact our support team.";
                modelErro.Title = "Oops! Page not found";
                modelErro.ErrorCode = id;
            }
            else if (id == 403)
            {
                modelErro.Message = "You are not allowed to do this.";
                modelErro.Title = "Access denied";
                modelErro.ErrorCode = id;
            }
            else
            {
                return StatusCode(500);
            }

            return View("Error", modelErro);
        }
    }
}
