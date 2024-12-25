using Microsoft.AspNetCore.Mvc;

namespace MyAuth.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login()
        {
            return View();
        }

    }
}
