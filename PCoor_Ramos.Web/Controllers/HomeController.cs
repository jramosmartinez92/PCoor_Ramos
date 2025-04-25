using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PCoor_Ramos.Web.Models;

namespace PCoor_Ramos.Web.Controllers
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [Route("Home/Error")]
        public IActionResult Error()
        {
            return View();
        }
    }
}
