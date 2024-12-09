using Microsoft.AspNetCore.Mvc;
using MyMVC.Models;
using System.Diagnostics;

namespace MyMVC.Controllers
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

        public IActionResult Contacts()
        {
            ViewData["STEP"] = "Hello Step";
            ViewBag.world = "Hello world";
            ViewData["city"] = new City() { id=1, name = "Astana"};
            ViewData["city_list"] = new List<City>()
            {
                new City{ id = 1, name = "Astana" },
                new City{ id = 2, name = "Almaty" },
            };

            ViewBag.city_list = new List<City>()
            {
                new City{ id = 1, name = "Astana" },
                new City{ id = 2, name = "Almaty" },
            };


            return View();
        }     


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
