using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using MyAuth.Abstract;
using MyAuth.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using ClosedXML.Excel;

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
                var claims = new[] { new Claim(ClaimTypes.Name, model.login) };
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

        [HttpGet, AllowAnonymous]
        public IActionResult Report()
        {
            return View();
        }

        [HttpGet, Route("GetExcel"), AllowAnonymous]
        public ActionResult GetExcel()
        {
            using (var ms = new MemoryStream())
            {
                using (XLWorkbook wb = new XLWorkbook())
                {
                    var ws = wb.AddWorksheet("report");
                    ws.Cell(1, 1).Value = "Id";
                    ws.Cell(1, 1).Style.Font.Bold = true;
                    ws.Cell(1, 1).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                    ws.Cell(1, 2).Value = "Name";
                    ws.Cell(1, 2).Style.Font.Bold = true;
                    ws.Cell(1, 2).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                    //ws.Column(1).Width = 25;
                    //ws.Column(2).Width = 15;

                    //List<Student> lst = new List<Student>()
                    //{
                    //    new Student{Id=1, Name="Иванов" },
                    //    new Student{Id=2, Name="Петров" }
                    //};

                    //ws.Cell(2, 1).InsertData(lst);
                    //ws.Cell(2, 1).InsertData(null);
                    ws.RangeUsed().SetAutoFilter();
                    ws.Columns("A", "B").AdjustToContents();

                    ws.SheetView.FreezeRows(1);
                    wb.SaveAs(ms);
                    ms.Position = 0;
                    ms.Flush();
                    var bytes = ms.ToArray();

                    return File(bytes,
                    "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                    "report____" + DateTime.Now.ToString("ddMMyyyy_hhmmss") + ".xlsx");
                }
            }
        }
    }
}
