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
        public ActionResult Index()
        {
            return View(service.GetAllCity());
        }

        // GET: CityController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CityController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CityController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(City model)
        {
            try
            {
                service.CityAdd(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CityController/Edit/5
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
