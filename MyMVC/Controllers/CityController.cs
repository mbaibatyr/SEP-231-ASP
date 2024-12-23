using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyMVC.Abstract;
using MyMVC.Models;

namespace MyMVC.Controllers
{
    public class CityController : Controller
    {
        ICity service;
        public CityController(ICity service)
        {
            this.service = service;
        }

        [AcceptVerbs("Get", "Post")]
        public ActionResult CheckEmail(string mail)
        {
            if (mail == "admin@mail.ru" || mail == "aaa@gmail.com")
                return Json(false);
            return Json(true);
        }
        public ActionResult Index()
        {
            return View(service.GetAllCity());
        }

        // GET: CityController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(City model)
        {
            try
            {
                //if (!ModelState.IsValid)
                if(true)
                {
                    ModelState.AddModelError("", "error");
                    return View();
                }
                service.CityAdd(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CityController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CityController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CityController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
