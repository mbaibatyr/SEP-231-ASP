using Microsoft.AspNetCore.Mvc;
using MyMVC.Models;

namespace MyMVC.Controllers
{
    public class MyController : Controller
    {
        IConfiguration config;
        public MyController(IConfiguration config)
        {
            this.config = config;
        }

        public IActionResult Index()
        {
            City city = new City { id = 1, name = "Astana" };
            ViewData["city"] = city;
            return View(city);
        }

        public IActionResult List()
        {
            var db = config["db"];
            var db2 = config.GetConnectionString("db");
            var value3 = config.GetSection("data:value3").Value;

            List<City> list = new List<City>()
            {
                new City { id = 1, name = "Astana" },
                new City { id = 2, name = "Almaty" },
                new City { id = 3, name = "Aktobe" }
            };
            ViewData["list"] = list;
            return View(list);
        }
    }
}
