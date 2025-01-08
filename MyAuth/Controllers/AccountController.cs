using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using MyAuth.Abstract;
using MyAuth.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace MyAuth.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        IUser service;

        public AccountController(IUser service)
        {
            this.service = service;
        }

        [HttpGet, AllowAnonymous]
        public IActionResult Login()
        {            
            return View();
        }

        [HttpPost, AllowAnonymous]
        public IActionResult Login(SignInRequest model)
        {
            var result = service.SignIn(model);
            if (result)
            {
                var claims = new[] { new Claim(ClaimTypes.Name, model.login)};
                var identity = new ClaimsIdentity(claims,
                  CookieAuthenticationDefaults.AuthenticationScheme);
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(identity));
                return Redirect("~/Home/Index");
            }
            ModelState.AddModelError("", "Login and/or password is not correct");
            return View();
        }

        [HttpGet, AllowAnonymous]
        public IActionResult SignUp()
        {
            ViewData["GetRoles"] = service.GetRoles();
            return View();
        }

        [HttpPost, AllowAnonymous]
        public IActionResult SignUp(SignUpRequest model)
        {
            var result = service.SignUp(model);
            if (result)
            {
                //var claims = new[] { new Claim(ClaimTypes.Name, model.login) };
                //var identity = new ClaimsIdentity(claims,
                //  CookieAuthenticationDefaults.AuthenticationScheme);
                //HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                //    new ClaimsPrincipal(identity));
                return Redirect("~/Account/Login");
            }
            ModelState.AddModelError("", "Login registered already");
            ViewData["GetRoles"] = service.GetRoles();
            return View();
        }
    }
}
