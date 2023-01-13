using Imi.Project.Vue.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Imi.Project.Vue.Controllers
{
    public class HomeController: Controller
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

        public IActionResult Genres()
        {
            return View();
        }

        public IActionResult Games()
        {
            return View();
        }

        public IActionResult Publishers()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult CurrentUser()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
