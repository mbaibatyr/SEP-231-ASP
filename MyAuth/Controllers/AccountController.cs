using Microsoft.AspNetCore.Mvc;
using MyAuth.Abstract;
using MyAuth.Models;

namespace MyAuth.Controllers
{
    public class AccountController : Controller
    {
        IUser service;

        public AccountController(IUser service)
        {
            this.service = service;
        }

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
        public IActionResult Login(User model)
        {
            //var result = service.SignIn(new SignInRequest { login = "user1", psw = "1234+" });
            return View();
        }

    }
}
